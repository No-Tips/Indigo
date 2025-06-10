using Content.Server.Atmos.Piping.Binary.Components;
using Content.Server.NodeContainer;
using Content.Server.NodeContainer.EntitySystems;
using Content.Server.NodeContainer.Nodes;
using Content.Shared.Atmos;
using Content.Shared.Atmos.Piping.Binary.GasPipeAdapter;
using Robust.Server.GameObjects;
using Robust.Shared.Utility;


namespace Content.Server.Atmos.Piping.Binary.EntitySystems;


public sealed class GasPipeAdapterSystem : EntitySystem
{
    [Dependency] private readonly UserInterfaceSystem _uiSystem = null!;
    [Dependency] private readonly AppearanceSystem _appearanceSystem = null!;
    [Dependency] private readonly NodeContainerSystem _nodeContainerSystem = null!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<GasPipeAdapterComponent, ComponentStartup>(OnComponentStartup);
        SubscribeLocalEvent<GasPipeAdapterComponent, BoundUIOpenedEvent>(OnBoundUiOpened);
        SubscribeLocalEvent<GasPipeAdapterComponent, GasPipeAdapterLayerSelectedMessage>(OnGasPipeAdapterLayerSelected);
    }

    private void OnComponentStartup(EntityUid uid, GasPipeAdapterComponent component, ComponentStartup args)
    {
        UpdateAppearance(uid, component);

        if (!TryComp(uid, out NodeContainerComponent? nodeContainer))
            return;

        if (!_nodeContainerSystem.TryGetNode(nodeContainer, component.InletNode, out PipeNode? inletNode))
            return;

        if (!_nodeContainerSystem.TryGetNode(nodeContainer, component.OutletNode, out PipeNode? outletNode))
            return;

        inletNode.Layer = component.InletLayer;
        outletNode.Layer = component.OutletLayer;

        inletNode.AddAlwaysReachable(outletNode);
        outletNode.AddAlwaysReachable(inletNode);
    }

    private void OnGasPipeAdapterLayerSelected(
        EntityUid uid,
        GasPipeAdapterComponent component,
        GasPipeAdapterLayerSelectedMessage args
    )
    {
        DebugTools.Assert(args.Layer < Atmospherics.MaxPipeLayers);

        var layer = Math.Clamp(args.Layer, 0, Atmospherics.MaxPipeLayers - 1);

        switch (args.LayerType)
        {
            case GasPipeAdapterLayerType.Inlet:
                component.InletLayer = layer;

                break;
            case GasPipeAdapterLayerType.Outlet:
                component.OutletLayer = layer;

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        UpdateState(uid, component);
    }

    private void UpdateState(EntityUid uid, GasPipeAdapterComponent? component)
    {
        if (!Resolve(uid, ref component))
            return;

        var nodeContainer = Comp<NodeContainerComponent>(uid);

        if (_nodeContainerSystem.TryGetNode(nodeContainer, component.InletNode, out PipeNode? inletNode))
        {
            inletNode.Layer = component.InletLayer;
            inletNode.ConnectionsEnabled = true;
        }

        if (_nodeContainerSystem.TryGetNode(nodeContainer, component.OutletNode, out PipeNode? outletNode))
        {
            outletNode.Layer = component.OutletLayer;
            outletNode.ConnectionsEnabled = true;
        }

        UpdateAppearance(uid, component);
        UpdateUiState(uid, component);
    }

    private void OnBoundUiOpened(EntityUid uid, GasPipeAdapterComponent component, BoundUIOpenedEvent args)
    {
        UpdateUiState(uid, component);
    }

    private void UpdateAppearance(EntityUid uid, GasPipeAdapterComponent? component)
    {
        if (!Resolve(uid, ref component))
            return;

        if (!TryComp(uid, out AppearanceComponent? appearance))
            return;

        _appearanceSystem.SetData(uid, GasPipeAdapterVisuals.InletLayer, component.InletLayer, appearance);
        _appearanceSystem.SetData(uid, GasPipeAdapterVisuals.OutletLayer, component.OutletLayer, appearance);
    }

    private void UpdateUiState(EntityUid uid, GasPipeAdapterComponent? component)
    {
        if (!Resolve(uid, ref component))
            return;

        var state = new GasPipeAdapterUiState(component.InletLayer, component.OutletLayer);

        _uiSystem.SetUiState(uid, GasPipeAdapterUiKey.Key, state);
    }
}
