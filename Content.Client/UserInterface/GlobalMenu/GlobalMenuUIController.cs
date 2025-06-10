// Copyright (C) 2025 Igor Spichkin

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.

// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using Content.Client.Gameplay;
using Content.Shared.Localizations;
using Robust.Client.UserInterface.Controllers;
using Robust.Shared.Timing;
using Robust.Shared.Utility;


namespace Content.Client.UserInterface.GlobalMenu;


public sealed partial class GlobalMenuUIController : UIController, IOnStateChanged<GameplayState>
{
    public event Action<LocalizedString, LocalizedString>? ItemPressed;

    private UI.GlobalMenu? GlobalMenu => UIManager.GetActiveUIWidgetOrNull<UI.GlobalMenu>();

    private IReadOnlyList<UI.GlobalMenu.Category> _categories = [];
    private bool                                  _isDirty;
    private bool                                  _isFirstTimeRebuild;

    public void Populate(IReadOnlyList<UI.GlobalMenu.Category> categories)
    {
        _categories = categories;
        _isDirty    = true;
    }

    public override void FrameUpdate(FrameEventArgs args)
    {
        base.FrameUpdate(args);

        if (!_isDirty)
            return;

        _isDirty = false;
        ReBuild();
    }

    private void ReBuild()
    {
        GlobalMenu?.Populate(_categories);

        // For some reason it won't appear correct
        if (_isFirstTimeRebuild)
        {
            _isFirstTimeRebuild = false;
            GlobalMenu?.ForceRunStyleUpdate();
        }
    }

    private void OnItemPressed(LocalizedString category, LocalizedString item) => ItemPressed?.Invoke(category, item);

    public void OnStateEntered(GameplayState state)
    {
        DebugTools.AssertNotNull(GlobalMenu);

        GlobalMenu!.ItemPressed += OnItemPressed;
        _isFirstTimeRebuild     =  true;
    }

    public void OnStateExited(GameplayState state)
    {
        if (GlobalMenu is { } globalMenu)
            globalMenu.ItemPressed -= OnItemPressed;
    }
}
