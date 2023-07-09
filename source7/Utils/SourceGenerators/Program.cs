using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Text.RegularExpressions;
using System;

namespace SourceGenerators;

// TODO clean this up and make it proper
internal class Program
{
    class CollectionClass
    {
        public class Member
        {
            public string Name;
            public string Type;
            public string GenericType = string.Empty;
            public string GenericTypeRoot = string.Empty;
            public bool IsGeneric;
            public bool IsEnum;
            public bool IsNullable;

            public Member(string name, string type)
            {
                Name = name;
                Type = type.TrimEnd('?');
                IsGeneric = type.Contains('<');
                if (IsGeneric)
                {
                    var regex = Regex.Match(type, @"(.+)<(.+)>");
                    if (regex.Success)
                    {
                        GenericTypeRoot = regex.Groups[1].Value;
                        GenericType = regex.Groups[2].Value;
                    }
                }
            }

            public override string ToString()
            {
                return $"{Name}:{Type}:{GenericType}";
            }
        }

        public string? Name { get; set; }
        public string? DbName { get; set; }
        public bool UseMemoryCache { get; set; }
        public string? BaseType;
        public List<Member> Members { get; } = new();

        public CollectionClass(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {UseMemoryCache} {DbName}";
        }
    }

    static void Main(string[] args)
    {
        string collectionOutFile = @"c:\Devel\Playnite\source7\Playnite\App\Library_Collections.generated.cs";
        string modelsFile = @"c:\Devel\Playnite\source7\PlayniteSDK\Models\PlayniteModels.cs";
        string dbobjectFile = @"c:\Devel\Playnite\source7\PlayniteSDK\Models\DatabaseObject.cs";

        var code = new CodeGen();
        var source = File.ReadAllText(modelsFile);
        var tree = CSharpSyntaxTree.ParseText(source);
        var root = tree.GetCompilationUnitRoot();
        var compilation = CSharpCompilation.Create("GameModelsCompilation").
            AddReferences(MetadataReference.CreateFromFile(typeof(string).Assembly.Location)).
            AddSyntaxTrees(CSharpSyntaxTree.ParseText(File.ReadAllText(dbobjectFile))).
            AddSyntaxTrees(tree);
        var model = compilation.GetSemanticModel(tree);

        var collectionClasses = new List<CollectionClass>();
        var cloneClasses = new List<CollectionClass>();
        var inuseClasses = new List<CollectionClass>();

        foreach (var node in root.DescendantNodes().OfType<ClassDeclarationSyntax>())
        {
            if (node!.AttributeLists.Count == 0)
            {
                continue;
            }

            if (node!.AttributeLists.First().Attributes.Count == 0)
            {
                continue;
            }

            var a = node!.AttributeLists[0].ToString();
            var b = node!.AttributeLists[0].GetText();

            var att = node!.AttributeLists.FirstOrDefault(a => a.ToString().StartsWith("[LibraryCollection", StringComparison.Ordinal));
            if (att != null)
            {
                var attSyntax = att.Attributes.First(a => a.Name.NormalizeWhitespace().ToFullString() == "LibraryCollection");
                var colClass = new CollectionClass(node.Identifier.Text);
                foreach (var argument in attSyntax.ArgumentList!.Arguments)
                {
                    var argumentName = argument.NameEquals?.Name.Identifier.ValueText;
                    var argumentValue = model.GetConstantValue(argument.Expression).ToString();

                    if (argumentName == "UseMemoryCache")
                    {
                        colClass.UseMemoryCache = bool.Parse(argumentValue);
                    }
                    else if (argumentName == "DbName")
                    {
                        colClass.DbName = argumentValue;
                    }
                }

                collectionClasses.Add(colClass);
            }

            att = att = node!.AttributeLists.FirstOrDefault(a => a.ToString().StartsWith("[AddCopyMethod", StringComparison.Ordinal));
            if (att != null)
            {
                var cloneClass = new CollectionClass(node.Identifier.Text);
                cloneClass.BaseType = node.BaseList?.Types.FirstOrDefault()?.ToString();
                var tt = model.Compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);

                foreach (var typeSymbol in tt!.GetBaseTypesAndThis())
                {
                    foreach (IFieldSymbol field in typeSymbol!.GetMembers().Where(a => a.Kind == SymbolKind.Field))
                    {
                        if (field.Name.Contains("k__BackingField", StringComparison.Ordinal))
                        {
                            continue;
                        }

                        cloneClass.Members.Add(new(field.Name, field.Type.ToString()!)
                        {
                            IsEnum = field.Type.TypeKind == TypeKind.Enum,
                            IsNullable = field.Type.NullableAnnotation == NullableAnnotation.Annotated
                        });
                    }

                    foreach (IPropertySymbol field in typeSymbol!.GetMembers().Where(a => a.Kind == SymbolKind.Property))
                    {
                        cloneClass.Members.Add(new(field.Name, field.Type.ToString()!)
                        {
                            IsEnum = field.Type.TypeKind == TypeKind.Enum,
                            IsNullable = field.Type.NullableAnnotation == NullableAnnotation.Annotated
                        });
                    }
                }

                cloneClasses.Add(cloneClass);
            }

            att = att = node!.AttributeLists.FirstOrDefault(a => a.ToString().StartsWith("[GenerateInUse", StringComparison.Ordinal));
            if (att != null)
            {
                var inuseClass = new CollectionClass(node.Identifier.Text);
                inuseClasses.Add(inuseClass);
            }
        }

        code.AddLine("""
            using System.Diagnostics.CodeAnalysis;
            using System.IO;
            namespace Playnite;

            """);

        foreach (var cls in collectionClasses)
        {
            using var _ = code.MakeScope($"public partial class {cls.Name}Collection : DatabaseCollection<{cls.Name}>");
            using var __ = code.MakeScope($"public {cls.Name}Collection(Library lib, CustomSqliteDb db) : base(lib, db, {cls.UseMemoryCache.ToString().ToLower()})");
        }

        // Collection members
        using (var _ = code.MakeScope("public partial class Library"))
        {
            foreach (var cls in collectionClasses)
            {
                code.AddLine($"[AllowNull] public {cls.Name}Collection {ToPlural(cls.Name!)} {{ get; private set; }}");
            }

            // In use properties
            foreach (var cls in inuseClasses)
            {
                code.AddLine($"public HashSet<Guid> Used{ToPlural(cls.Name!)} {{ get; }} = new();");
                code.AddLine($"public event EventHandler? {ToPlural(cls.Name!)}InUseUpdated;");
            }

            // LoadCollection
            using (var __ = code.MakeScope("private void LoadCollections()"))
            {
                foreach (var dbName in collectionClasses.GroupBy(a => a.DbName))
                {
                    code.AddLine($"sqliteDbs.Add(\"{dbName.Key}\", new CustomSqliteDb(Path.Combine(LibraryDir, \"{dbName.Key}.db\")));");
                }

                foreach (var cls in collectionClasses)
                {
                    code.AddLine($"{ToPlural(cls.Name!)} = new(this, sqliteDbs[\"{cls.DbName}\"]);");
                }
            }
        }

        File.WriteAllText(collectionOutFile, code.ToString());

        // Models GetCopy
        code = new CodeGen();
        code.AddLine("""
            namespace Playnite;

            #pragma warning disable CS1591

            """);

        foreach (var cls in cloneClasses)
        {
            using var _ = code.MakeScope($"public partial class {cls.Name} : ICopyable<{cls.Name}>");
            using var __ = code.MakeScope($"public {cls.Name} GetCopy()");

            code.AddLine($"var copy = new {cls.Name}();");
            foreach (var member in cls.Members)
            {
                var propName = string.Concat(member.Name[0].ToString().ToUpper(), member.Name.AsSpan(1));
                if (member.IsGeneric)
                {
                    if (knownStructs.Contains(member.GenericType))
                    {
                        if (member.IsNullable)
                        {
                            code.AddLine($"copy.{propName} = {propName} is null ? null : new({propName});");
                        }
                        else
                        {
                            code.AddLine($"copy.{propName} = new({propName});");
                        }
                    }
                    else if (cloneClasses.FirstOrDefault(a => "Playnite." + a.Name == member.GenericType) != null)
                    {
                        code.AddLine($"copy.{propName} = {propName}?.Select(a => a.GetCopy()).To{member.GenericTypeRoot}();");
                    }
                    else
                    {
                        throw new Exception($"Uknown generic type to handle copy of {member.Type} {member.Name}");
                    }
                }
                else if (knownStructs.Contains(member.Type) || member.IsEnum)
                {
                    code.AddLine($"copy.{propName} = {propName};");
                }
                else if (cloneClasses.FirstOrDefault(a => "Playnite." + a.Name == member.Type) != null)
                {
                    code.AddLine($"copy.{propName} = {propName}{(member.IsNullable ? "?" : string.Empty)}.GetCopy();");
                }
                else if (member.Type == "PartialDate")
                {
                    code.AddLine($"copy.{propName} = {propName}{(member.IsNullable ? "?" : string.Empty)}.GetCopy();");
                }
                else
                {
                    throw new Exception($"Uknown type to handle copy of {member.Type} {member.Name}");
                }
            }

            code.AddLine("return copy;");
        }

        File.WriteAllText(@"c:\Devel\Playnite\source7\PlayniteSDK\Models\PlayniteModels.generated.cs", code.ToString());

        code = new CodeGen();
        code.AddLine("""
            namespace Playnite.Tests;

            """);

        using (var _ = code.MakeScope($"public partial class PlayniteModelsTests"))
        {
            using var __ = code.MakeScope($"[Test] public void GetCopyTests()");
            foreach (var cls in cloneClasses)
            {
                code.AddLine($"GetCopyTest<{cls.Name}>();");
            }
        }

        File.WriteAllText(@"C:\Devel\Playnite\source7\Tests\Playnite.Tests\App\PlayniteModels.Tests.generated.cs", code.ToString());

        // Generate public static dialogs class
        var dialogsMethods = ParseIDialogs(@"C:\Devel\Playnite\source7\PlayniteSDK\IDialogs.cs");

        code = new CodeGen();
        code.AddLine("""
        using System.Diagnostics.CodeAnalysis;
        namespace Playnite;

        """);

        using (var _ = code.MakeScope($"public partial class Dialogs"))
        {
            code.AddLine("""
                [AllowNull] public static IDialogs DialogsHandler { get; private set; }

                internal static void SetHandler(IDialogs factory)
                {
                    DialogsHandler = factory;
                }
                """);

            foreach (var method in dialogsMethods)
            {
                code.AddLine($$"""

                public static {{method.Declaration}}
                {
                    {{(method.ReturnType == "void" ? string.Empty : "return ")}}DialogsHandler.{{method.Name}}({{string.Join(", ", method.Params!)}});
                }
                """);
            }
        }

        File.WriteAllText(@"C:\Devel\Playnite\source7\Playnite\Dialogs.generated.cs", code.ToString());
    }

    public class IterfaceMethod
    {
        public string? Name;
        public string? ReturnType;
        public string? Declaration;
        public List<string>? Params;
    }

    private static List<IterfaceMethod> ParseIDialogs(string sourceFile)
    {
        var methods = new List<IterfaceMethod>();
        var source = File.ReadAllText(sourceFile);
        var tree = CSharpSyntaxTree.ParseText(source);
        var root = tree.GetCompilationUnitRoot();
        var compilation = CSharpCompilation.Create("IDialogsCompilation")
            .AddReferences(MetadataReference.CreateFromFile(typeof(string).Assembly.Location))
            .AddSyntaxTrees(tree);
        var model = compilation.GetSemanticModel(tree);

        var collectionClasses = new List<CollectionClass>();
        var cloneClasses = new List<CollectionClass>();
        var inuseClasses = new List<CollectionClass>();

        foreach (var node in root.DescendantNodes().OfType<InterfaceDeclarationSyntax>())
        {
            var typeSymbol = model.Compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node)!;
            if (typeSymbol.Name != "IDialogs")
            {
                continue;
            }

            foreach (var method in node.DescendantNodes().OfType<MethodDeclarationSyntax>())
            {
                var name = method.Identifier.Text;
                var returnType = method.ReturnType.ToString();
                var args = method.ParameterList.ToString();
                var args2 = method.ParameterList.Parameters.Select(a => a.Identifier.Text).ToList();
                var str = method.ToString();

                methods.Add(new()
                {
                    Name = name,
                    ReturnType = returnType,
                    Declaration = str.TrimEnd(';'),
                    Params = args2
                });
            }

            //foreach (var method in typeSymbol.GetMembers().Where(a => a.Kind == SymbolKind.Method))
            //{
            //    //var str = method.OriginalDefinition.un();
            //}
        }

        return methods;
    }

    private static readonly HashSet<string> knownStructs = new()
    {
        "int",
        "uint",
        "long",
        "ulong",
        "decimal",
        "float",
        "bool",
        "string",
        "Guid",
        "DateTime",
        "short"
    };

    public static string ToPlural(string input)
    {
        if (input.EndsWith("us", StringComparison.OrdinalIgnoreCase))
        {
            return string.Concat(input.AsSpan(0, input.Length - 2), "uses");
        }

        if (input.EndsWith("s", StringComparison.OrdinalIgnoreCase))
        {
            return input;
        }

        if (input.EndsWith("y", StringComparison.OrdinalIgnoreCase))
        {
            return input.TrimEnd('y') + "ies";
        }

        return input + "s";
    }
}

public static class Extensions
{
    public static IEnumerable<ITypeSymbol> GetBaseTypesAndThis(this ITypeSymbol type)
    {
        var current = type;
        while (current != null)
        {
            yield return current;
            current = current.BaseType;
        }
    }
}