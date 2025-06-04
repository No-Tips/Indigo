namespace Content.Shared.Prototypes;

[Serializable]
public enum NavMapBlipPlacement
{
    Centered, // The blip appears in the center of the tile
    Offset    // The blip is offset from the center of the tile (determined by the system using the blips)
}
