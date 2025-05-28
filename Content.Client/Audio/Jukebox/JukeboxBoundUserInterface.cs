using Content.Shared.Audio.Jukebox;
using Robust.Client.UserInterface;
using Robust.Shared.Audio.Components;
using Robust.Shared.Utility;


namespace Content.Client.Audio.Jukebox;


public sealed class JukeboxBoundUserInterface : BoundUserInterface
{
    [ViewVariables]
    private JukeboxMenu? _menu;

    [ViewVariables]
    private JukeboxUiState _state = new();

    public JukeboxBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
        IoCManager.InjectDependencies(this);
    }

    protected override void Open()
    {
        base.Open();

        _menu = this.CreateWindow<JukeboxMenu>();

        _menu.OnPlayPressed += args =>
        {
            if (args)
                SendMessage(new JukeboxPlayingMessage());
            else
                SendMessage(new JukeboxPauseMessage());
        };

        _menu.OnStopPressed += () =>
        {
            SendMessage(new JukeboxStopMessage());
        };

        _menu.OnSongSelected += trackId => SendMessage(new JukeboxSelectedMessage(trackId));
        _menu.SetTime += OnSetTime;

        Reload();
    }

    protected override void UpdateState(BoundUserInterfaceState state)
    {
        if (state is not JukeboxUiState castedState)
            return;

        _state = castedState;

        Reload();
    }

    public void OnSetTime(float time)
    {
        // You may be wondering, what the fuck is this
        // Well we want to be able to predict the playback slider change, of which there are many ways to do it
        // We can't just use SendPredictedMessage because it will reset every tick and audio updates every frame
        // so it will go BRRRRT
        // Using ping gets us close enough that it SHOULD, MOST OF THE TIME, fall within the 0.1 second tolerance
        // that's still on engine so our playback position never gets corrected.
        if (EntMan.TryGetComponent(Owner, out JukeboxComponent? jukebox) &&
            EntMan.TryGetComponent(jukebox.AudioStream, out AudioComponent? audioComp))
        {
            audioComp.PlaybackPosition = time;
        }

        SendMessage(new JukeboxSetTimeMessage(time));
    }

    /// <summary>
    /// Reloads the attached menu if it exists.
    /// </summary>
    private void Reload()
    {
        if (_menu == null)
            return;

        _menu.Populate(with: _state.Tracks);
        _menu.SetAudioStream(fromEntity: _state.AudioStream);

        if (_state.SelectedTrackId is { } trackId)
        {
            var track = _state.Tracks.FirstOrNull(t => t.Id == trackId);

            _menu.SetSelectedTrack(fromTrack: track);
        }
        else
            _menu.SetSelectedTrack(fromTrack: null);
    }
}
