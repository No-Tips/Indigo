using System.Text;
using Content.Client.InterfaceGuidelines;
using Content.Client.Resources;
using Content.Shared.Access.Components;
using Content.Shared.InterfaceGuidelines;
using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Shared.Enums;

namespace Content.Client.Access;

public sealed class AccessOverlay : Overlay
{
    private readonly IEntityManager _entityManager;
    private readonly SharedTransformSystem _transformSystem;
    private readonly Font _font;

    public override OverlaySpace Space => OverlaySpace.ScreenSpace;

    public AccessOverlay(IEntityManager entityManager, TypographyManager typographyManager, SharedTransformSystem transformSystem)
    {
        _entityManager = entityManager;
        _transformSystem = transformSystem;
        _font = typographyManager.GetFont(FontType.SansSerif, TextStyle.Callout);
    }

    protected override void Draw(in OverlayDrawArgs args)
    {
        if (args.ViewportControl == null)
            return;

        var textBuffer = new StringBuilder();
        var query = _entityManager.EntityQueryEnumerator<AccessReaderComponent, TransformComponent>();
        while (query.MoveNext(out var uid, out var accessReader, out var transform))
        {
            textBuffer.Clear();

            var entityName = _entityManager.ToPrettyString(uid);
            textBuffer.AppendLine(entityName.Prototype);
            textBuffer.Append("UID: ");
            textBuffer.Append(entityName.Uid.Id);
            textBuffer.Append(", NUID: ");
            textBuffer.Append(entityName.Nuid.Id);
            textBuffer.AppendLine();

            if (!accessReader.Enabled)
            {
                textBuffer.AppendLine("-Disabled");
                continue;
            }

            if (accessReader.AccessLists.Count > 0)
            {
                var groupNumber = 0;
                foreach (var accessList in accessReader.AccessLists)
                {
                    groupNumber++;
                    foreach (var entry in accessList)
                    {
                        textBuffer.Append("+Set ");
                        textBuffer.Append(groupNumber);
                        textBuffer.Append(": ");
                        textBuffer.Append(entry.Id);
                        textBuffer.AppendLine();
                    }
                }
            }
            else
            {
                textBuffer.AppendLine("+Unrestricted");
            }

            foreach (var key in accessReader.AccessKeys)
            {
                textBuffer.Append("+Key ");
                textBuffer.Append(key.OriginStation);
                textBuffer.Append(": ");
                textBuffer.Append(key.Id);
                textBuffer.AppendLine();
            }

            foreach (var tag in accessReader.DenyTags)
            {
                textBuffer.Append("-Tag ");
                textBuffer.AppendLine(tag.Id);
            }

            var accessInfoText = textBuffer.ToString();
            var screenPos = args.ViewportControl.WorldToScreen(_transformSystem.GetWorldPosition(transform));
            args.ScreenHandle.DrawString(_font, screenPos, accessInfoText, Color.Gold);
        }
    }
}
