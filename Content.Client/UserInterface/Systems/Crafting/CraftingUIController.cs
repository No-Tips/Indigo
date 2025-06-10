using Content.Client.Construction.UI;
using Content.Client.Gameplay;
using Content.Client.UserInterface.GlobalMenu;
using Content.Shared.Input;
using JetBrains.Annotations;
using Robust.Client.UserInterface.Controllers;
using Robust.Shared.Utility;

namespace Content.Client.UserInterface.Systems.Crafting;

[UsedImplicitly]
public sealed class CraftingUIController : UIController, IOnStateChanged<GameplayState>
{
    [Dependency] private readonly GlobalMenuManager _globalMenuManager = null!;

    private ConstructionMenuPresenter? _presenter;

    public override void Initialize()
    {
        base.Initialize();

        _globalMenuManager
            .GetCategory(GlobalMenuCategory.Character)
            .RegisterItem(
                new(
                    new("global-menu-character-crafting-window-item"),
                    Callback: () => _presenter?.ToggleWindow(),
                    Function: ContentKeyFunctions.OpenCraftingMenu
                )
            );
    }

    public void OnStateEntered(GameplayState state)
    {
        DebugTools.Assert(_presenter == null);
        _presenter = new ConstructionMenuPresenter();
    }

    public void OnStateExited(GameplayState state)
    {
        if (_presenter == null)
            return;
        UnloadButton(_presenter);
        _presenter.Dispose();
        _presenter = null;
    }

    internal void UnloadButton(ConstructionMenuPresenter? presenter = null)
    {
        if (presenter == null)
        {
            presenter ??= _presenter;
            if (presenter == null)
            {
                return;
            }
        }
    }
}
