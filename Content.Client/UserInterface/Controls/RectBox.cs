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

            var borderThickness = new Thickness(borders.Thickness);

            if (InsetBorders is { } insetBorders)
            {
                handle.DrawRoundedRect(borderThickness.Deflate(box), Rounding, insetBorders.Color, uiScale);

                borderThickness = new((borders.Thickness) + (insetBorders.Thickness));
            }

            handle.DrawRoundedRect(borderThickness.Deflate(box), Rounding, BackgroundColor, uiScale);
        }
        else
        {
            var borderThickness = new Thickness(0.0f);

            if (InsetBorders is { } insetBorders)
            {
                handle.DrawRoundedRect(borderThickness.Deflate(box), Rounding, insetBorders.Color, uiScale);

                borderThickness = new(insetBorders.Thickness);
            }

            handle.DrawRoundedRect(borderThickness.Deflate(box), Rounding, BackgroundColor, uiScale);
        }
    }
}
