﻿using Content.Client.InterfaceGuidelines;
using Content.Shared.InterfaceGuidelines;
using Content.Shared.Verbs;
using Robust.Client.UserInterface.Controls;


namespace Content.Client.Examine;


/// <summary>
///     Buttons that show up in the examine tooltip to specify more detailed
///     ways to examine an item.
/// </summary>
public sealed class ExamineButton : ContainerButton
{
    [Dependency] private readonly TypographyManager _typographyManager = null!;

    public const string StyleClassExamineButton = "examine-button";

    public const int ElementHeight = 32;
    public const int ElementWidth  = 32;

    private const int Thickness = 4;

    public Label Icon;

    public ExamineVerb Verb;

    public ExamineButton(ExamineVerb verb)
    {
        Margin = new(Thickness, Thickness, Thickness, Thickness);

        SetOnlyStyleClass(StyleClassExamineButton);

        Verb = verb;

        if (verb.Disabled)
            Disabled = true;

        ToolTip = verb.Message ?? verb.Text;

        Icon = new();

        if (verb.GlyphIcon == null)
            return;

        Icon.Text = verb.GlyphIcon;
        Icon.SetOnlyStyleClass(UIStyleClasses.LabelIconFilledRegular1);

        AddChild(Icon);
    }
}
