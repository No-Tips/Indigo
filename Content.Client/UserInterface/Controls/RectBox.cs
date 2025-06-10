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

using Content.Client.Graphics;
using Robust.Client.Graphics;


namespace Content.Client.UserInterface.Controls;


public sealed class RectBox : StyleBox
{
    public Color BackgroundColor { get; set; }

    public Border? Borders { get; set; }

    public Border? InsetBorders { get; set; }

    public Rounding Rounding { get; set; }

    protected override void DoDraw(DrawingHandleScreen handle, UIBox2 box, float uiScale)
    {
        if (Borders is { } borders)
        {
            handle.DrawRoundedRect(box, Rounding, borders.Color, uiScale);

            var borderThickness = borders.Thickness;

            if (InsetBorders is { } insetBorders)
            {
                handle.DrawRoundedRect(borderThickness.Deflate(box), Rounding, insetBorders.Color, uiScale);

                borderThickness = new(
                    borderThickness.Left + insetBorders.Thickness.Left,
                    borderThickness.Top + insetBorders.Thickness.Top,
                    borderThickness.Right + insetBorders.Thickness.Right,
                    borderThickness.Bottom + insetBorders.Thickness.Bottom
                );
            }

            handle.DrawRoundedRect(borderThickness.Deflate(box), Rounding, BackgroundColor, uiScale);
        }
        else
        {
            var borderThickness = new Thickness(0.0f);

            if (InsetBorders is { } insetBorders)
            {
                handle.DrawRoundedRect(borderThickness.Deflate(box), Rounding, insetBorders.Color, uiScale);

                borderThickness = insetBorders.Thickness;
            }

            handle.DrawRoundedRect(borderThickness.Deflate(box), Rounding, BackgroundColor, uiScale);
        }
    }
}
