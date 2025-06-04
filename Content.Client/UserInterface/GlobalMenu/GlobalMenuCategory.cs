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

namespace Content.Client.UserInterface.GlobalMenu;


public static class GlobalMenuCategory
{
    public static readonly GlobalMenuCategoryDef Game = new(
        new("global-menu-game-category"),
        GlobalMenuCategoryPriority.Game,
        IsIcon: true
    );

    public static readonly GlobalMenuCategoryDef Character = new(
        new("global-menu-character-category"),
        GlobalMenuCategoryPriority.Character
    );

    public static readonly GlobalMenuCategoryDef Ghost = new(
        new("global-menu-ghost-category"),
        GlobalMenuCategoryPriority.Ghost
    );

    public static readonly GlobalMenuCategoryDef Admin = new(
        new("global-menu-admin-category"),
        GlobalMenuCategoryPriority.Admin
    );

    public static readonly GlobalMenuCategoryDef Sandbox = new(
        new("global-menu-sandbox-category"),
        GlobalMenuCategoryPriority.Sandbox
    );
}
