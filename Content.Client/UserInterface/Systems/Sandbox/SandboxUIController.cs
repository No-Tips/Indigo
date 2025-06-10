﻿using Content.Client.Administration.Managers;
using Content.Client.Gameplay;
using Content.Client.Markers;
using Content.Client.Sandbox;
using Content.Client.UserInterface.Controls;
using Content.Client.UserInterface.GlobalMenu;
using Content.Client.UserInterface.Systems.DecalPlacer;
using Content.Client.UserInterface.Systems.Sandbox.Windows;
using Content.Shared.Input;
using JetBrains.Annotations;
using Robust.Client.Debugging;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controllers;
using Robust.Client.UserInterface.Controllers.Implementations;
using Robust.Shared.Console;
using Robust.Shared.Input.Binding;
using Robust.Shared.Map;
using Robust.Shared.Player;
using Robust.Shared.Utility;
using static Robust.Client.UserInterface.Controls.BaseButton;

namespace Content.Client.UserInterface.Systems.Sandbox;

// TODO hud refactor should part of this be in engine?
[UsedImplicitly]
public sealed class SandboxUIController : UIController, IOnStateChanged<GameplayState>, IOnSystemChanged<SandboxSystem>
{
    [Dependency] private readonly IConsoleHost        _console           = default!;
    [Dependency] private readonly IEyeManager         _eye               = default!;
    [Dependency] private readonly IInputManager       _input             = default!;
    [Dependency] private readonly ILightManager       _light             = default!;
    [Dependency] private readonly IClientAdminManager _admin             = default!;
    [Dependency] private readonly IPlayerManager      _player            = default!;
    [Dependency] private readonly GlobalMenuManager   _globalMenuManager = null!;

    [UISystemDependency] private readonly DebugPhysicsSystem _debugPhysics = default!;
    [UISystemDependency] private readonly MarkerSystem _marker = default!;
    [UISystemDependency] private readonly SandboxSystem _sandbox = default!;

    private SandboxWindow? _window;

    // TODO hud refactor cache
    private EntitySpawningUIController EntitySpawningController => UIManager.GetUIController<EntitySpawningUIController>();
    private TileSpawningUIController TileSpawningController => UIManager.GetUIController<TileSpawningUIController>();
    private DecalPlacerUIController DecalPlacerController => UIManager.GetUIController<DecalPlacerUIController>();

    private GlobalMenuItemDef _panelItem;
    private GlobalMenuItemDef _entitySpawningWindowItem;
    private GlobalMenuItemDef _tileSpawnWindowItem;
    private GlobalMenuItemDef _decalSpawnWindowItem;

    public override void Initialize()
    {
        base.Initialize();

        _panelItem = new(
            new("global-menu-sandbox-panel-item"),
            Callback: ToggleWindow,
            Function: ContentKeyFunctions.OpenSandboxWindow,
            Priority: 1000,
            InGameState: typeof(GameplayState)
        );

        _entitySpawningWindowItem = new(
            new("global-menu-sandbox-entity-spawning-window-item"),
            Callback: () =>
            {
                if (_admin.CanAdminPlace())
                    EntitySpawningController.ToggleWindow();
            },
            Function: ContentKeyFunctions.OpenEntitySpawnWindow,
            InGameState: typeof(GameplayState)
        );

        _tileSpawnWindowItem = new(
            new("global-menu-sandbox-tile-spawn-window-item"),
            Callback: () =>
            {
                if (_admin.CanAdminPlace())
                    TileSpawningController.ToggleWindow();
            },
            Function: ContentKeyFunctions.OpenTileSpawnWindow,
            InGameState: typeof(GameplayState)
        );

        _decalSpawnWindowItem = new(
            new("global-menu-sandbox-decal-spawn-window-item"),
            Callback: () =>
            {
                if (_admin.CanAdminPlace())
                    DecalPlacerController.ToggleWindow();
            },
            Function: ContentKeyFunctions.OpenDecalSpawnWindow,
            InGameState: typeof(GameplayState)
        );

        _admin.AdminStatusUpdated += OnAdminStatusUpdated;
    }

    public void OnStateEntered(GameplayState state)
    {
        DebugTools.Assert(_window == null);
        EnsureWindow();

        OnAdminStatusUpdated();
    }

    private void EnsureWindow()
    {
        if (_window is { Disposed: false })
            return;
        _window = UIManager.CreateWindow<SandboxWindow>();
        // Pre-center the window without forcing it to the center every time.
        _window.OpenCentered();
        _window.Close();

        // TODO: These need moving to opened so at least if they're not synced properly on open they work.
        _window.ToggleLightButton.Pressed = !_light.Enabled;
        _window.ToggleFovButton.Pressed = !_eye.CurrentEye.DrawFov;
        _window.ToggleShadowsButton.Pressed = !_light.DrawShadows;
        _window.ShowMarkersButton.Pressed = _marker.MarkersVisible;
        _window.ShowBbButton.Pressed = (_debugPhysics.Flags & PhysicsDebugFlags.Shapes) != 0x0;

        _window.AiOverlayButton.OnPressed += args =>
        {
            var player = _player.LocalEntity;

            if (player == null)
                return;

            var pnent = EntityManager.GetNetEntity(player.Value);

            // Need NetworkedAddComponent but engine PR.
            if (args.Button.Pressed)
                _console.ExecuteCommand($"addcomp {pnent.Id} StationAiOverlay");
            else
                _console.ExecuteCommand($"rmcomp {pnent.Id} StationAiOverlay");
        };
        _window.RespawnButton.OnPressed += _ => _sandbox.Respawn();
        _window.SpawnTilesButton.OnPressed += _ => TileSpawningController.ToggleWindow();
        _window.SpawnEntitiesButton.OnPressed += _ => EntitySpawningController.ToggleWindow();
        _window.SpawnDecalsButton.OnPressed += _ => DecalPlacerController.ToggleWindow();
        _window.GiveFullAccessButton.OnPressed += _ => _sandbox.GiveAdminAccess();
        _window.GiveAghostButton.OnPressed += _ => _sandbox.GiveAGhost();
        _window.ToggleLightButton.OnToggled += _ => _sandbox.ToggleLight();
        _window.ToggleFovButton.OnToggled += _ => _sandbox.ToggleFov();
        _window.ToggleShadowsButton.OnToggled += _ => _sandbox.ToggleShadows();
        _window.SuicideButton.OnPressed += _ => _sandbox.Suicide();
        _window.ToggleSubfloorButton.OnPressed += _ => _sandbox.ToggleSubFloor();
        _window.ShowMarkersButton.OnPressed += _ => _sandbox.ShowMarkers();
        _window.ShowBbButton.OnPressed += _ => _sandbox.ShowBb();
    }

    public void OnStateExited(GameplayState state)
    {
        if (_window != null)
        {
            _window.Close();
            _window = null;
        }

        OnAdminStatusUpdated();
    }

    public void OnSystemLoaded(SandboxSystem system)
    {
        system.SandboxDisabled += CloseAll;
    }

    public void OnSystemUnloaded(SandboxSystem system)
    {
        system.SandboxDisabled -= CloseAll;
    }

    private void OnAdminStatusUpdated()
    {
        var isAdmin = _admin.CanAdminPlace();

        _globalMenuManager
            .GetCategory(GlobalMenuCategory.Sandbox)
            .KeepItem(_panelItem, when: isAdmin)
            .KeepItem(_entitySpawningWindowItem, when: isAdmin)
            .KeepItem(_tileSpawnWindowItem, when: isAdmin)
            .KeepItem(_decalSpawnWindowItem, when: isAdmin);
    }

    private void CloseAll()
    {
        _window?.Close();
        EntitySpawningController.CloseWindow();
        TileSpawningController.CloseWindow();
    }

    private bool Copy(ICommonSession? session, EntityCoordinates coords, EntityUid uid)
    {
        return _sandbox.Copy(session, coords, uid);
    }

    private void ToggleWindow()
    {
        if (_window == null)
            return;
        if (_sandbox.SandboxAllowed && _window.IsOpen != true)
        {
            UIManager.ClickSound();
            _window.Open();
        }
        else
        {
            UIManager.ClickSound();
            _window.Close();
        }
    }

    #region Buttons

    public void SetToggleSubfloors(bool value)
    {
        if (_window == null)
            return;

        _window.ToggleSubfloorButton.Pressed = value;
    }

    #endregion
}
