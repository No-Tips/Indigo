using Content.Shared.Audio.Jukebox;
using Robust.Client.Animations;
using Robust.Client.GameObjects;
using Robust.Client.ResourceManagement;
using Robust.Shared.Prototypes;


namespace Content.Client.Audio.Jukebox;


public sealed class JukeboxSystem : SharedJukeboxSystem
{
    [Dependency] private readonly IPrototypeManager _prototypeManager = null!;
    [Dependency] private readonly AnimationPlayerSystem _animationPlayer = null!;
    [Dependency] private readonly SharedAppearanceSystem _appearanceSystem = null!;
    [Dependency] private readonly SharedUserInterfaceSystem _uiSystem = null!;
    [Dependency] private readonly IResourceCache _resourceCache = null!;

    private List<JukeboxTrack> _tracks = [];

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<JukeboxComponent, AppearanceChangeEvent>(OnAppearanceChange);
        SubscribeLocalEvent<JukeboxComponent, AnimationCompletedEvent>(OnAnimationCompleted);
        SubscribeLocalEvent<JukeboxComponent, AfterAutoHandleStateEvent>(OnAfterAutoHandleState);
        SubscribeLocalEvent<JukeboxComponent, BoundUIOpenedEvent>(OnBoundUIOpened);

        _prototypeManager.PrototypesReloaded += OnPrototypeReload;
        _tracks = LoadTracks();
    }

    public override void Shutdown()
    {
        base.Shutdown();
        _prototypeManager.PrototypesReloaded -= OnPrototypeReload;
    }

    private void OnAfterAutoHandleState(Entity<JukeboxComponent> ent, ref AfterAutoHandleStateEvent args) =>
        UpdateUiState(ent);

    private void OnBoundUIOpened(Entity<JukeboxComponent> ent, ref BoundUIOpenedEvent args) => UpdateUiState(ent);

    private void UpdateUiState(Entity<JukeboxComponent> ent)
    {
        UserInterfaceComponent? ui = null;

        var (uid, comp) = ent;

        if (!Resolve(uid, ref ui))
            return;

        _uiSystem.SetUiState(
            new(uid, ui),
            JukeboxUiKey.Key,
            new JukeboxUiState(_tracks, comp.SelectedTrackId, comp.AudioStream));
    }

    private void OnPrototypeReload(PrototypesReloadedEventArgs obj)
    {
        if (!obj.WasModified<JukeboxPrototype>())
            return;

        _tracks = LoadTracks();

        var state = new JukeboxUiState(tracks: _tracks);
        var query = AllEntityQuery<JukeboxComponent, UserInterfaceComponent>();

        while (query.MoveNext(out var uid, out _, out var ui))
            _uiSystem.SetUiState(new(uid, ui), JukeboxUiKey.Key, state);
    }

    private void OnAnimationCompleted(EntityUid uid, JukeboxComponent component, AnimationCompletedEvent args)
    {
        if (!TryComp<SpriteComponent>(uid, out var sprite))
            return;

        if (!TryComp<AppearanceComponent>(uid, out var appearance) ||
            !_appearanceSystem.TryGetData<JukeboxVisualState>(
                uid,
                JukeboxVisuals.VisualState,
                out var visualState,
                appearance))
        {
            visualState = JukeboxVisualState.On;
        }

        UpdateAppearance(uid, visualState, component, sprite);
    }

    private void OnAppearanceChange(EntityUid uid, JukeboxComponent component, ref AppearanceChangeEvent args)
    {
        if (args.Sprite == null)
            return;

        if (!args.AppearanceData.TryGetValue(JukeboxVisuals.VisualState, out var visualStateObject) ||
            visualStateObject is not JukeboxVisualState visualState)
        {
            visualState = JukeboxVisualState.On;
        }

        UpdateAppearance(uid, visualState, component, args.Sprite);
    }

    private void UpdateAppearance(
        EntityUid uid,
        JukeboxVisualState visualState,
        JukeboxComponent component,
        SpriteComponent sprite
    )
    {
        SetLayerState(JukeboxVisualLayers.Base, component.OffState, sprite);

        switch (visualState)
        {
            case JukeboxVisualState.On:
                SetLayerState(JukeboxVisualLayers.Base, component.OnState, sprite);
                break;

            case JukeboxVisualState.Off:
                SetLayerState(JukeboxVisualLayers.Base, component.OffState, sprite);
                break;

            case JukeboxVisualState.Select:
                PlayAnimation(uid, JukeboxVisualLayers.Base, component.SelectState, 1.0f, sprite);
                break;
        }
    }

    private void PlayAnimation(
        EntityUid uid,
        JukeboxVisualLayers layer,
        string? state,
        float animationTime,
        SpriteComponent sprite
    )
    {
        if (string.IsNullOrEmpty(state))
            return;

        if (_animationPlayer.HasRunningAnimation(uid, state))
            return;

        var animation = GetAnimation(layer, state, animationTime);

        sprite.LayerSetVisible(layer, true);
        _animationPlayer.Play(uid, animation, state);
    }

    private static Animation GetAnimation(JukeboxVisualLayers layer, string state, float animationTime) =>
        new()
        {
            Length = TimeSpan.FromSeconds(animationTime),
            AnimationTracks =
            {
                new AnimationTrackSpriteFlick
                {
                    LayerKey = layer,
                    KeyFrames =
                    {
                        new AnimationTrackSpriteFlick.KeyFrame(state, 0f)
                    }
                }
            }
        };

    private static void SetLayerState(JukeboxVisualLayers layer, string? state, SpriteComponent sprite)
    {
        if (string.IsNullOrEmpty(state))
            return;

        sprite.LayerSetVisible(layer, true);
        sprite.LayerSetAutoAnimated(layer, true);
        sprite.LayerSetState(layer, state);
    }

    private List<JukeboxTrack> LoadTracks()
    {
        var tracks = new List<JukeboxTrack>();

        foreach (var proto in _prototypeManager.EnumeratePrototypes<JukeboxPrototype>())
        {
            if (!_resourceCache.TryGetResource(proto.Path.Path, out AudioResource? res))
            {
                Log.Error("Failed to get an audio resource for file '{}'", proto.Path);

                continue;
            }

            tracks.Add(
                new JukeboxTrack(
                    proto.ID,
                    res.AudioStream.Title,
                    res.AudioStream.Artist,
                    res.AudioStream.Length,
                    proto.Path.Path));

            res.Dispose();
        }

        return tracks;
    }
}
