using Content.Client.UserInterface;
using Robust.Client.Graphics;


namespace Content.Client.Graphics;


public static class DrawingHandleScreenExtensions
{
    public static void DrawRoundedRect(
        this DrawingHandleScreen handle,
        UIBox2                   box,
        Rounding                 rounding,
        Color                    color,
        float                    uiScale,
        bool                     filled = true
    )
    {
        if (rounding.Sum() <= 0.0f)
        {
            handle.DrawRect(box, color, filled);

            return;
        }

        // Circle vertices use Color.FromSrgb, WTF?
        var srgbBackgroundColor = Color.ToSrgb(color);

        // Corners

        var topLeftRadius     = rounding.TopLeft * uiScale;
        var topRightRadius    = rounding.TopRight * uiScale;
        var bottomRightRadius = rounding.BottomRight * uiScale;
        var bottomLeftRadius  = rounding.BottomLeft * uiScale;

        var topLeftCorner = box.TopLeft with
        {
            X = box.TopLeft.X + topLeftRadius, Y = box.TopLeft.Y + topLeftRadius
        };
        var topRightCorner = box.TopRight with
        {
            X = box.TopRight.X - topRightRadius, Y = box.TopRight.Y + topRightRadius
        };
        var bottomRightCorner = box.BottomRight with
        {
            X = box.BottomRight.X - bottomRightRadius, Y = box.BottomRight.Y - bottomRightRadius
        };
        var bottomLeftCorner = box.BottomLeft with
        {
            X = box.BottomLeft.X + bottomLeftRadius, Y = box.BottomLeft.Y - bottomLeftRadius
        };

        handle.DrawCircle(
            topLeftCorner,
            topLeftRadius,
            srgbBackgroundColor,
            filled
        );
        handle.DrawCircle(
            topRightCorner,
            topRightRadius,
            srgbBackgroundColor,
            filled
        );
        handle.DrawCircle(
            bottomRightCorner,
            bottomRightRadius,
            srgbBackgroundColor,
            filled
        );
        handle.DrawCircle(
            bottomLeftCorner,
            bottomLeftRadius,
            srgbBackgroundColor,
            filled
        );

        // Borders

        var maxTopRadius    = Math.Max(topLeftRadius, topRightRadius);
        var maxRightRadius  = Math.Max(topRightRadius, bottomRightRadius);
        var maxBottomRadius = Math.Max(bottomLeftRadius, bottomRightRadius);
        var maxLeftRadius   = Math.Max(topLeftRadius, bottomLeftRadius);

        var topBorderRect = UIBox2.FromDimensions(
            box.Left + maxTopRadius,
            box.Top,
            box.Width - maxTopRadius * 2,
            maxTopRadius
        );
        var rightBorderRect = UIBox2.FromDimensions(
            box.Right - maxRightRadius,
            box.Top + maxRightRadius,
            maxRightRadius,
            box.Height - maxRightRadius * 2
        );
        var bottomBorderRect = UIBox2.FromDimensions(
            box.Left + maxBottomRadius,
            box.Bottom - maxBottomRadius,
            box.Width - maxBottomRadius * 2,
            maxBottomRadius
        );
        var leftBorderRect = UIBox2.FromDimensions(
            box.Left,
            box.Top + maxLeftRadius,
            maxLeftRadius,
            box.Height - maxLeftRadius * 2
        );

        handle.DrawRect(topBorderRect, color, filled);
        handle.DrawRect(rightBorderRect, color, filled);
        handle.DrawRect(bottomBorderRect, color, filled);
        handle.DrawRect(leftBorderRect, color, filled);

        // Inner rect

        var innerRect = new UIBox2(topBorderRect.BottomLeft, rightBorderRect.BottomLeft);

        handle.DrawRect(innerRect, color, filled);
    }
}
