using Robust.Shared.Utility;


namespace Content.Client.Audio.Jukebox;


public record struct JukeboxTrack(string Id, string? Title, string? Artist, TimeSpan Length, ResPath Path)
{
    public override string ToString()
    {
        var title = string.IsNullOrEmpty(Title) ? "Unknown" : Title;
        var artist = string.IsNullOrEmpty(Artist) ? "Unknown" : Artist;

        return $"{artist} - {title}";
    }
}
