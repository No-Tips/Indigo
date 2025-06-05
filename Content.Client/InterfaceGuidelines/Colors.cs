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

namespace Content.Client.InterfaceGuidelines;


public static class Colors
{
    public static readonly Color Black = Color.FromHex("#191919");
    public static readonly Color Gray  = Color.FromHex("#353535");

    #region Window

    public static          Color WindowBackground => Black;
    public static readonly Color WindowBorder      = new(0, 0, 0);
    public static readonly Color WindowInsetBorder = new(48, 48, 48);

    public static          Color WindowTitlebarBackground => Gray;
    public static          Color WindowTitlebarBorder     => WindowBorder;
    public static readonly Color WindowTitlebarInsetBorder = new(73, 73, 73);

    #endregion

    #region Chat

    public static Color ChatBorder      => WindowBorder;
    public static Color ChatInsetBorder => WindowInsetBorder;
    public static Color ChatBackground  => Black;

    #endregion

    #region Global Menu

    public static Color GlobalMenuBorder      => WindowBorder;
    public static Color GlobalMenuInsetBorder => WindowInsetBorder;
    public static Color GlobalMenuBackground  => Black;

    #endregion
}
