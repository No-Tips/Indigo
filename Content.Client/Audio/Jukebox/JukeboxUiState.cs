namespace Content.Client.Audio.Jukebox;


public sealed class JukeboxUiState : BoundUserInterfaceState
{
    public IReadOnlyList<JukeboxTrack> Tracks { get; } = [];

    public string? SelectedTrackId { get; }

    public EntityUid? AudioStream { get; }

    public JukeboxUiState() { }

    public JukeboxUiState(IReadOnlyList<JukeboxTrack> tracks)
    {
        Tracks = tracks;
    }

    public JukeboxUiState(
        IReadOnlyList<JukeboxTrack> tracks,
        string? selectedTrackId = null,
        EntityUid? audioStream = null
    )
    {
        Tracks = tracks;
        SelectedTrackId = selectedTrackId;
        AudioStream = audioStream;
    }
}
