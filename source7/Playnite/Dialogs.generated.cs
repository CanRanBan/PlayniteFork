#nullable enable
using System.Diagnostics.CodeAnalysis;
namespace Playnite;

public partial class Dialogs
{
    [AllowNull] public static IDialogs DialogsHandler { get; private set; }

    internal static void SetHandler(IDialogs factory)
    {
        DialogsHandler = factory;
    }

    public static MessageBoxResult ShowErrorMessage(string messageBoxText)
    {
        return DialogsHandler.ShowErrorMessage(messageBoxText);
    }

    public static MessageBoxResult ShowErrorMessage(string messageBoxText, string caption)
    {
        return DialogsHandler.ShowErrorMessage(messageBoxText, caption);
    }

    public static MessageBoxResult ShowMessage(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
    {
        return DialogsHandler.ShowMessage(messageBoxText, caption, button, icon);
    }

    public static MessageBoxResult ShowMessage(string messageBoxText, string caption, MessageBoxButton button)
    {
        return DialogsHandler.ShowMessage(messageBoxText, caption, button);
    }

    public static MessageBoxResult ShowMessage(string messageBoxText, string caption)
    {
        return DialogsHandler.ShowMessage(messageBoxText, caption);
    }

    public static MessageBoxResult ShowMessage(string messageBoxText)
    {
        return DialogsHandler.ShowMessage(messageBoxText);
    }

    public static MessageBoxOption ShowMessage(
            string messageBoxText,
            string caption,
            MessageBoxImage icon,
            List<MessageBoxOption> options)
    {
        return DialogsHandler.ShowMessage(messageBoxText, caption, icon, options);
    }

    public static string SelectFolder()
    {
        return DialogsHandler.SelectFolder();
    }

    public static string SelectFile(string filter)
    {
        return DialogsHandler.SelectFile(filter);
    }

    public static List<string> SelectFiles(string filter)
    {
        return DialogsHandler.SelectFiles(filter);
    }

    public static string SelectIconFile()
    {
        return DialogsHandler.SelectIconFile();
    }

    public static string SelectImagefile()
    {
        return DialogsHandler.SelectImagefile();
    }

    public static string SaveFile(string filter)
    {
        return DialogsHandler.SaveFile(filter);
    }

    public static string SaveFile(string filter, bool promptOverwrite)
    {
        return DialogsHandler.SaveFile(filter, promptOverwrite);
    }

    public static StringSelectionDialogResult SelectString(
            string messageBoxText,
            string caption,
            string defaultInput)
    {
        return DialogsHandler.SelectString(messageBoxText, caption, defaultInput);
    }

    public static StringSelectionDialogResult SelectString(
            string messageBoxText,
            string caption,
            string defaultInput,
            List<MessageBoxToggle> options)
    {
        return DialogsHandler.SelectString(messageBoxText, caption, defaultInput, options);
    }

    public static void ShowSelectableString(
            string messageBoxText,
            string caption,
            string defaultInput)
    {
        DialogsHandler.ShowSelectableString(messageBoxText, caption, defaultInput);
    }

    public static ImageFileOption ChooseImageFile(
            List<ImageFileOption> files,
            string? caption = null,
            double itemWidth = 240,
            double itemHeight = 180)
    {
        return DialogsHandler.ChooseImageFile(files, caption, itemWidth, itemHeight);
    }

    public static GenericItemOption ChooseItemWithSearch(
            List<GenericItemOption> items,
            Func<string, List<GenericItemOption>> searchFunction,
            string? defaultSearch = null,
            string? caption = null)
    {
        return DialogsHandler.ChooseItemWithSearch(items, searchFunction, defaultSearch, caption);
    }

    public static GlobalProgressResult ActivateGlobalProgress(Action<GlobalProgressActionArgs> progresAction, GlobalProgressOptions progressOptions)
    {
        return DialogsHandler.ActivateGlobalProgress(progresAction, progressOptions);
    }

    public static GlobalProgressResult ActivateGlobalProgress(Func<GlobalProgressActionArgs, Task> progresAction, GlobalProgressOptions progressOptions)
    {
        return DialogsHandler.ActivateGlobalProgress(progresAction, progressOptions);
    }

    public static IWindow CreateWindow(WindowCreationOptions options)
    {
        return DialogsHandler.CreateWindow(options);
    }

    public static IWindow GetCurrentAppWindow()
    {
        return DialogsHandler.GetCurrentAppWindow();
    }
}
