using System.Linq;
using Content.Client.Gameplay;
using Content.Client.Guidebook;
using Content.Client.Guidebook.Controls;
using Content.Client.Lobby;
using Content.Client.UserInterface.GlobalMenu;
using Content.Shared.Guidebook;
using Content.Shared.Input;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controllers;
using static Robust.Client.UserInterface.Controls.BaseButton;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Client.UserInterface.Systems.Guidebook;

public sealed class GuidebookUIController : UIController, IOnStateEntered<LobbyState>, IOnStateEntered<GameplayState>, IOnStateExited<LobbyState>, IOnStateExited<GameplayState>, IOnSystemChanged<GuidebookSystem>
{
    [Dependency] private readonly IPrototypeManager _prototypeManager  = default!;
    [Dependency] private readonly GlobalMenuManager _globalMenuManager = null!;

    [UISystemDependency] private readonly GuidebookSystem _guidebookSystem = default!;

    private GuidebookWindow? _guideWindow;

    public override void Initialize()
    {
        base.Initialize();

        _globalMenuManager
            .GetCategory(GlobalMenuCategory.Global)
            .RegisterItem(
                new(
                    new("global-menu-global-guide-book-item"),
                    Callback: ToggleGuidebook,
                    Function: ContentKeyFunctions.OpenGuidebook
                )
            );
    }

    public void OnStateEntered(LobbyState state)
    {
        HandleStateEntered();
    }

    public void OnStateEntered(GameplayState state)
    {
        HandleStateEntered();
    }

    private void HandleStateEntered()
    {
        DebugTools.Assert(_guideWindow == null);

        // setup window
        _guideWindow = UIManager.CreateWindow<GuidebookWindow>();
    }

    public void OnStateExited(LobbyState state)
    {
        HandleStateExited();
    }

    public void OnStateExited(GameplayState state)
    {
        HandleStateExited();
    }

    private void HandleStateExited()
    {
        if (_guideWindow == null)
            return;

        // shutdown
        _guideWindow.Dispose();
        _guideWindow = null;
    }

    public void OnSystemLoaded(GuidebookSystem system)
    {
        _guidebookSystem.OnGuidebookOpen += OpenGuidebook;
    }

    public void OnSystemUnloaded(GuidebookSystem system)
    {
        _guidebookSystem.OnGuidebookOpen -= OpenGuidebook;
    }

    private void GuidebookButtonOnPressed(ButtonEventArgs obj)
    {
        ToggleGuidebook();
    }

    public void ToggleGuidebook()
    {
        if (_guideWindow == null)
            return;

        if (_guideWindow.IsOpen)
        {
            UIManager.ClickSound();
            _guideWindow.Close();
        }
        else
        {
            OpenGuidebook();
        }
    }

    /// <summary>
    ///     Opens or closes the guidebook.
    /// </summary>
    /// <param name="guides">What guides should be shown. If not specified, this will instead list all the entries</param>
    /// <param name="rootEntries">A list of guides that should form the base of the table of contents. If not specified,
    /// this will automatically simply be a list of all guides that have no parent.</param>
    /// <param name="forceRoot">This forces a singular guide to contain all other guides. This guide will
    /// contain its own children, in addition to what would normally be the root guides if this were not
    /// specified.</param>
    /// <param name="includeChildren">Whether or not to automatically include child entries. If false, this will ONLY
    /// show the specified entries</param>
    /// <param name="selected">The guide whose contents should be displayed when the guidebook is opened</param>
    public void OpenGuidebook(
        Dictionary<ProtoId<GuideEntryPrototype>, GuideEntry>? guides = null,
        List<ProtoId<GuideEntryPrototype>>? rootEntries = null,
        ProtoId<GuideEntryPrototype>? forceRoot = null,
        bool includeChildren = true,
        ProtoId<GuideEntryPrototype>? selected = null)
    {
        if (_guideWindow == null)
            return;

        if (guides == null)
        {
            guides = _prototypeManager.EnumeratePrototypes<GuideEntryPrototype>()
                .ToDictionary(x => new ProtoId<GuideEntryPrototype>(x.ID), x => (GuideEntry) x);
        }
        else if (includeChildren)
        {
            var oldGuides = guides;
            guides = new(oldGuides);
            foreach (var guide in oldGuides.Values)
            {
                RecursivelyAddChildren(guide, guides);
            }
        }

        _guideWindow.UpdateGuides(guides, rootEntries, forceRoot, selected);

        // Expand up to depth-2.
        _guideWindow.Tree.SetAllExpanded(false);
        _guideWindow.Tree.SetAllExpanded(true, 1);

        _guideWindow.OpenCenteredRight();
    }

    public void OpenGuidebook(
        List<ProtoId<GuideEntryPrototype>> guideList,
        List<ProtoId<GuideEntryPrototype>>? rootEntries = null,
        ProtoId<GuideEntryPrototype>? forceRoot = null,
        bool includeChildren = true,
        ProtoId<GuideEntryPrototype>? selected = null)
    {
        Dictionary<ProtoId<GuideEntryPrototype>, GuideEntry> guides = new();
        foreach (var guideId in guideList)
        {
            if (!_prototypeManager.TryIndex(guideId, out var guide))
            {
                Logger.GetSawmill("guidebook").Error($"Encountered unknown guide prototype: {guideId}");
                continue;
            }
            guides.Add(guideId, guide);
        }

        OpenGuidebook(guides, rootEntries, forceRoot, includeChildren, selected);
    }

    public void CloseGuidebook()
    {
        if (_guideWindow == null)
            return;

        if (_guideWindow.IsOpen)
        {
            UIManager.ClickSound();
            _guideWindow.Close();
        }
    }

    private void RecursivelyAddChildren(GuideEntry guide, Dictionary<ProtoId<GuideEntryPrototype>, GuideEntry> guides)
    {
        foreach (var childId in guide.Children)
        {
            if (guides.ContainsKey(childId))
                continue;

            if (!_prototypeManager.TryIndex(childId, out var child))
            {
                Logger.GetSawmill("guide.ui.control").Error($"Encountered unknown guide prototype: {childId} as a child of {guide.Id}. If the child is not a prototype, it must be directly provided.");
                continue;
            }

            guides.Add(childId, child);
            RecursivelyAddChildren(child, guides);
        }
    }
}
