using Content.Client.Changelog;
using Content.Client.UserInterface.GlobalMenu;
using JetBrains.Annotations;
using Robust.Client.State;
using Robust.Client.UserInterface.Controllers;

namespace Content.Client.UserInterface.Systems.EscapeMenu;

[UsedImplicitly]
public sealed class ChangelogUIController : UIController
{
    [Dependency] private readonly GlobalMenuManager _globalMenuManager = null!;

    private ChangelogWindow _changeLogWindow = default!;

    public override void Initialize()
    {
        base.Initialize();

        _globalMenuManager
            .GetCategory(GlobalMenuCategory.Game)
            .RegisterItem(
                new(
                    new("global-menu-game-changelog-item"),
                    Callback: ToggleWindow
                )
            );
    }

    public void OpenWindow()
    {
        EnsureWindow();

        _changeLogWindow.OpenCentered();
        _changeLogWindow.MoveToFront();
    }

    private void EnsureWindow()
    {
        if (_changeLogWindow is { Disposed: false })
            return;

        _changeLogWindow = UIManager.CreateWindow<ChangelogWindow>();
    }

    public void ToggleWindow()
    {
        EnsureWindow();

        if (_changeLogWindow.IsOpen)
        {
            _changeLogWindow.Close();
        }
        else
        {
            OpenWindow();
        }
    }
}
