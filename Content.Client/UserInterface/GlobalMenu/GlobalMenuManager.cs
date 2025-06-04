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

using System.Linq;
using Content.Client.Gameplay;
using Content.Client.UserInterface.GlobalMenu.UI;
using Content.Shared.Localizations;
using Robust.Client.Input;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controllers;
using Robust.Shared.Input.Binding;
using Robust.Shared.Timing;


namespace Content.Client.UserInterface.GlobalMenu;


public sealed class GlobalMenuManager : UIController, IOnStateChanged<GameplayState>
{
    [Dependency] private readonly IUserInterfaceManager _uiManager    = null!;
    [Dependency] private readonly IInputManager         _inputManager = null!;

    private GlobalMenuUIController                     _uiController         = null!;
    private Dictionary<LocalizedString, CategoryEntry> _registeredCategories = [];
    private bool                                       _isDirty;
    private bool                                       _isInGameplayState;

    public override void Initialize()
    {
        _uiController             =  _uiManager.GetUIController<GlobalMenuUIController>();
        _uiController.ItemPressed += OnItemPressed;

        _inputManager.OnKeyBindingAdded       += _ => QueueUpdate();
        _inputManager.OnKeyBindingRemoved     += _ => QueueUpdate();
        _inputManager.Contexts.ContextChanged += (_, _) => QueueUpdate();
    }

    public override void FrameUpdate(FrameEventArgs args)
    {
        base.FrameUpdate(args);

        if (!_isDirty)
            return;

        if (!_isInGameplayState)
            return;

        _isDirty = false;
        Update();
    }

    private void OnItemPressed(LocalizedString category, LocalizedString item)
    {
        var categoryEntry = _registeredCategories[category];
        var itemDef       = categoryEntry.GetItems()[item];

        itemDef.Callback();
    }

    public CategoryEntry GetCategory(GlobalMenuCategoryDef def)
    {
        if (_registeredCategories.TryGetValue(def.Name, out var category))
            return category;

        category = _registeredCategories[def.Name] = new(def, this);

        return category;
    }

    private void QueueUpdate() => _isDirty = true;

    private void Update()
    {
        _registeredCategories = _registeredCategories
            .Where(c => c.Value.GetItems().Count > 0)
            .ToDictionary();

        UpdateBinds();

        var currentContext = _inputManager.Contexts.ActiveContext;

        var categories =
            _registeredCategories.AsEnumerable()
                .OrderByDescending(c => c.Value.Define.Priority)
                .ThenBy(c => c.Value.Define.Name.ToString())
                .Select(c =>
                {
                    var items = c.Value.GetItems()
                        .AsEnumerable()
                        .Where(i =>
                        {
                            if (i.Value.Function is { } function)
                                return currentContext.FunctionExistsHierarchy(function);

                            return true;
                        })
                        .OrderByDescending(i => i.Value.Priority)
                        .ThenBy(i => i.Value.Name.ToString())
                        .Select(i =>
                        {
                            string? hotKey = null;

                            if (i.Value.Function is { } function && _inputManager.TryGetKeyBinding(function, out _))
                                hotKey = _inputManager.GetKeyFunctionButtonString(function);

                            return new GlobalMenuPopup.Item(i.Key, hotKey);
                        })
                        .ToList();

                    return new UI.GlobalMenu.Category(c.Key, items, c.Value.Define.IsIcon);
                })
                .Where(c => c.Items.Count > 0)
                .ToList();

        _uiController.Populate(categories);
    }

    private void UpdateBinds()
    {
        CommandBinds.Unregister<GlobalMenuManager>();

        var builder = CommandBinds.Builder;

        foreach (var (_, category) in _registeredCategories)
        {
            var items = category.GetItems();

            foreach (var (_, item) in items)
            {
                if (item.Function is { } function)
                {
                    builder
                        .Bind(function, InputCmdHandler.FromDelegate(_ => item.Callback()));
                }
            }
        }

        builder.Register<GlobalMenuManager>();
    }

    public sealed class CategoryEntry(GlobalMenuCategoryDef def, GlobalMenuManager parent)
    {
        public readonly GlobalMenuCategoryDef Define = def;

        private readonly Dictionary<LocalizedString, GlobalMenuItemDef> _items = [];

        public CategoryEntry RegisterItem(GlobalMenuItemDef itemDef)
        {
            _items.TryAdd(itemDef.Name, itemDef);
            parent.QueueUpdate();

            return this;
        }

        public CategoryEntry RemoveItem(GlobalMenuItemDef itemDef)
        {
            _items.Remove(itemDef.Name);
            parent.QueueUpdate();

            return this;
        }

        public CategoryEntry KeepItem(GlobalMenuItemDef itemDef, bool when) =>
            when ? RegisterItem(itemDef) : RemoveItem(itemDef);

        public IReadOnlyDictionary<LocalizedString, GlobalMenuItemDef> GetItems() => _items;
    }

    public void OnStateEntered(GameplayState state) => _isInGameplayState = true;

    public void OnStateExited(GameplayState state) => _isInGameplayState = false;
}
