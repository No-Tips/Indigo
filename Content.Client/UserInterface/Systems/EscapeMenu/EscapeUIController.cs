using Content.Client.UserInterface.GlobalMenu;
using JetBrains.Annotations;
using Robust.Client.Console;
using Robust.Client.UserInterface.Controllers;


namespace Content.Client.UserInterface.Systems.EscapeMenu;


[UsedImplicitly]
public sealed class EscapeUIController : UIController
{
    [Dependency] private readonly IClientConsoleHost _console           = null!;
    [Dependency] private readonly GlobalMenuManager  _globalMenuManager = null!;

    public override void Initialize()
    {
        base.Initialize();

        _globalMenuManager
            .GetCategory(GlobalMenuCategory.Game)
            .RegisterItem(
                new(
                    new("global-menu-game-disconnect-item"),
                    Callback: () => _console.ExecuteCommand("disconnect"),
                    Priority: -500
                )
            )
            .RegisterItem(
                new(
                    new("global-menu-game-quit-item"),
                    Callback: () => _console.ExecuteCommand("quit"),
                    Priority: -1000
                )
            );
    }
}
