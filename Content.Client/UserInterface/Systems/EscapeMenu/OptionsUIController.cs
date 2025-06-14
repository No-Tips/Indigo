using Content.Client.Gameplay;
using Content.Client.Options.UI;
using Content.Client.UserInterface.GlobalMenu;
using Content.Shared.Input;
using JetBrains.Annotations;
using Robust.Client.UserInterface.Controllers;
using Robust.Shared.Console;


namespace Content.Client.UserInterface.Systems.EscapeMenu;

[UsedImplicitly]
public sealed class OptionsUIController : UIController
{
    [Dependency] private readonly IConsoleHost      _con               = default!;
    [Dependency] private readonly GlobalMenuManager _globalMenuManager = null!;

    public override void Initialize()
    {
        _con.RegisterCommand("options", Loc.GetString("cmd-options-desc"), Loc.GetString("cmd-options-help"), OptionsCommand);

        _globalMenuManager
            .GetCategory(GlobalMenuCategory.Global)
            .RegisterItem(
                new(
                    new("global-menu-global-options-item"),
                    Callback: ToggleWindow,
                    Function: ContentKeyFunctions.OpenOptionsWindow
                )
            );
    }

    private void OptionsCommand(IConsoleShell shell, string argStr, string[] args)
    {
        if (args.Length == 0)
        {
            ToggleWindow();
            return;
        }
        OpenWindow();

        if (!int.TryParse(args[0], out var tab))
        {
            shell.WriteError(Loc.GetString("cmd-parse-failure-int", ("arg", args[0])));
            return;
        }

        _optionsWindow.Tabs.CurrentTab = tab;
    }

    private OptionsMenu _optionsWindow = default!;

    private void EnsureWindow()
    {
        if (_optionsWindow is { Disposed: false })
            return;

        _optionsWindow = UIManager.CreateWindow<OptionsMenu>();
    }

    public void OpenWindow()
    {
        EnsureWindow();

        _optionsWindow.UpdateTabs();

        _optionsWindow.OpenCentered();
        _optionsWindow.MoveToFront();
    }

    public void ToggleWindow()
    {
        EnsureWindow();

        if (_optionsWindow.IsOpen)
        {
            _optionsWindow.Close();
        }
        else
        {
            OpenWindow();
        }
    }
}
