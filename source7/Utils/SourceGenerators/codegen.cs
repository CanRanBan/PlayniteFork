using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SourceGenerators;

public class CodeGen
{
    public class BracketsScope : IDisposable
    {
        private readonly CodeGen code;

        public BracketsScope(CodeGen code, string parent)
        {
            this.code = code;
            if (code.sb.ToString().TrimEnd().EndsWith('}'))
            {
                code.AddLine();
            }

            code.AddLine(parent);
            code.AddLine("{");
            code.Indentation += 1;
        }

        public void Dispose()
        {
            code.Indentation -= 1;
            code.AddLine("}");
        }
    }

    private const string indent = "    ";
    public StringBuilder sb = new();
    public int Indentation = 0;

    public CodeGen()
    {
        sb.AppendLine("#nullable enable");
    }

    public BracketsScope MakeScope(string parent)
    {
        return new BracketsScope(this, parent);
    }

    public void AddLine()
    {
        sb.AppendLine();
    }

    public void AddLine(string line)
    {
        foreach (var item in line.Split(Environment.NewLine))
        {
            if (item.IsNullOrEmpty())
            {
                sb.AppendLine();
                continue;
            }

            sb.AppendLine(indent.Multiply(Indentation) + item);
        }
    }

    public override string ToString()
    {
        return sb.ToString();
    }
}