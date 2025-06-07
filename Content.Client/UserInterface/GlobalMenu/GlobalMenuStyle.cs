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

using Content.Shared.InterfaceGuidelines;


namespace Content.Client.UserInterface.GlobalMenu;


public readonly record struct GlobalMenuStyle(Color Background, Color Border, Color InsetBorder)
{
    public static readonly GlobalMenuStyle Default = new(
        Colors.WindowBackground,
        Colors.WindowBorder,
        Colors.WindowInsetBorder);

    public static readonly GlobalMenuStyle Combat = new(Colors.Red, Colors.WindowBorder, Color.FromHex("#ef6d6e"));
}
