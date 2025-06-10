namespace Content.Client.UserInterface;


public readonly record struct Rounding(float TopLeft, float TopRight, float BottomRight, float BottomLeft)
{
    public Rounding(float uniform) : this(uniform, uniform, uniform, uniform) { }

    public float Sum() => TopLeft + TopRight + BottomRight + BottomLeft;
}
