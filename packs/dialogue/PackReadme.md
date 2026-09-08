# Astra Dialogue — 0.1.2 local candidate

Create branching conversations in Unity with multi-line bubbles, project-defined
conditions, a playable preview, and reviewed Excel exchanges. The runtime has no
mandatory dependency on the Astra Framework or optional Astra tools.

## Try the orchard

Open `Demo/Generated/Orchard.unity` and press Play. Robin starts a conversation.
Click the card (or submit with the focused card) to reveal a line, then advance.
Give Robin a pear, close the conversation and speak again: the next opening changes.
Use the basket buttons to exercise available/unavailable answers.

`Tools > Astra > Dialogue > Open` opens the authoring window. Double-click the
Orchard conversation to edit it. The source demo belongs to the pack: duplicate
content into your game folder before customization. `Tools > Astra > Dialogue >
Create Orchard Demo` generates a separate editable example under
`Assets/DialogueOrchardDemo` and refuses to overwrite that folder.

## Write a conversation

1. Create a character using `Create > Astra > Dialogue > Character`.
2. Create a conversation using `Create > Astra > Dialogue > Conversation`.
3. Open Dialogue Studio, add a Dialogue passage and set it as the entry.
4. Add several lines in its Write panel. Each line can use a different character.
5. Add a Choice passage and answers. Click an output dot then a destination
   bubble, or use the destination menus in the Write panel.
6. Add conditions with their named menus. Conditions match All or Any and can be
   inverted or nested. An empty All group is unrestricted; empty Any is false.
7. Run Preview. Choose the Orchard inventory context for the demo's game conditions.
   Preview skips all gameplay actions and never acquires player control.
8. Save. Drag bubbles to arrange them; wheel zooms, middle drag pans, Shift selects
   multiple bubbles, Ctrl/Cmd+D duplicates, Ctrl/Cmd+C/V copies/pastes and Delete removes selected passages.
   Shortcuts are ignored while a text field has the keyboard. Pasted passages land in a
   cascade around the visible centre of the canvas; only duplicates get a "copy" suffix.

Changing a passage kind hides the ports the new kind does not use. A value left on a
hidden port is neither followed nor reported; deleting a passage clears every link to it.
Validation runs after each edit, undo, load and project change. The graph layout asset
under `Editor/DialogueLayouts` is only created when missing.

Nodes: Dialogue, Choice, Branch, Action, End. An empty destination ends the
conversation, except an answer requires a real target (use an End node).
If no answer is enabled, Choice uses its fallback or ends. An unavailable answer
is hidden by default; Disabled keeps it visible with an explanation while other
answers remain available. Every answer is rechecked when selected.

## Add your game's condition

Put extensions in your game's assembly, referencing `Astra.Dialogue`. Provide a
serializable subclass and a stable registered identity:

```csharp
[Serializable, DialogueExtension("mygame.inventory.has-key", "Inventory/Has key")]
public sealed class HasKeyCondition : DialogueCondition
{
    public string Key = "garden";
    public override DialogueConditionResult Evaluate(IDialogueContext context)
    {
        if (!context.TryGet<IMyInventory>(out var inventory))
            return DialogueConditionResult.Error("Missing inventory provider.");
        return inventory.HasKey(Key)
            ? DialogueConditionResult.Pass()
            : DialogueConditionResult.Unavailable("Find the garden key first.");
    }
}
```

`DialogueContext.With<IMyInventory>(inventory)` binds that capability. A component
implementing `IDialogueContextProvider` supplies the context to `DialogueRunner`.
The designer sees the extension under Add condition and edits its serialized fields.
Keep Evaluate synchronous and free of side effects. Return Error for missing or
invalid configuration; this never passes, even within Any/Negate.

Implement `DialogueAction.ExecuteAsync(context, cancellationToken)` for effects.
Respect cancellation, and let the host own transactional gameplay changes.
A session serializes transitions and rejects duplicate selections while an action
is in progress. A new session can execute actions again: durable rewards require
the game's own state/idempotency rules.

`IDialogueControl.AcquireDialogueControl()` returns a disposable lease for movement,
interaction or camera ownership. The runner releases it on completion, failure,
cancellation and disable. The engine never changes global time or a controller by
itself. The demo shows lease ownership without coupling to a movement implementation.

## Save and localize

`DialogueVariables.Capture/Restore` handles the provided string variable store.
The host owns storage and saves its world state alongside narrative variables.
`CaptureCheckpoint(contentRevision)` captures only an idle line/choice wait point.
Restore into a new session with `RestoreCheckpointAsync(checkpoint, contentRevision)`.
The host must provide an immutable revision for its narrative content and migrate
old saves when this changes. Actions are not replayed while restoring that point.
There is no automatic save migration or mid-action checkpoint.

Provide `IDialogueTextResolver` for localization. Lines and choices use their
explicit key or `line.<stable-id>` / `choice.<stable-id>`, with authored text as fallback.
Character names and condition explanations currently use authored display text;
full translation tooling remains an integration task.

## Exchange with Excel

Export XLSX in Dialogue Studio, edit a copy, then Import XLSX into the same
conversation. The menu `Tools > Astra > Dialogue > Import Workbook as New Conversation` starts a new asset from an exported workbook with fresh identities. The workbook contains one whole conversation and an export baseline
identity. Keep existing Id values. New rows may use unique readable IDs; destinations
refer to those IDs. Identities are unique per sheet, so a passage and a line may both be
called `intro`: every link resolves in the sheet it points to. Order is numeric, starts
at zero, and is local to the parent. Use literal cell values. Formulas and
partial-conversation workbooks are rejected.

Cells that hold links (Passage, Speaker, Target, Next, Otherwise, Owner, Parent, Entry,
Conversation) are trimmed on import. A row without an Id receives a generated one and is
listed as `+ Sheet/<id> (generated Id)` in the import review. A Metadata row whose key
column is empty is ignored; a missing key, sheet relationship or Conversations row is
reported by name. Imported characters are saved as `Characters/<display name>.asset`.

All sheets are required, even when empty: Metadata, Conversations, Passages, Lines,
Choices, Characters, Conditions, Actions, Parameters. Guide describes the workflow.
Every passage and answer has one root condition group. Parameters holds one row
per scalar parameter of a non-group condition/action; Owner points to that extension.
A group uses Type `astra.group`, Version `1`, Operator `All`/`Any`, Negate `True`/`False`.
Use the exported example rather than inventing type IDs or parameter names.

Import compares the baseline, current Unity content and incoming workbook by ID
and field. Independent changes merge; divergent edits and delete-versus-modify
conflicts require a choice. A stale preview must be prepared again. Baselines live
under your content's `Editor/DialogueExchange/<asset-guid>/Bases`: version this
folder. Missing/changed baselines disable automatic merging.

The review window lists the resulting changes and dry-runs the merged conversation as
soon as every conflict is resolved. A merge that cannot build, for example two new
passages sharing an Order, shows its error under the list and keeps Apply disabled.

Before applying, the importer keeps recovery copies under
`<project>/Library/Astra/DialogueExchange/Recovery/<id>/`, outside `Assets`, so they
are never imported. `paths.json` maps each numbered backup to its project-relative
asset path. The 20 most recent copies are kept; older ones are deleted at each import.
Restore intentionally after closing Unity if needed; normal successful imports can also
be undone in the editor. Projects updated from 0.1.1 may still hold a
`Editor/DialogueExchange/Recovery` folder next to their conversations: it is no longer
written and can be deleted with its `.meta` file. Portraits and Unity object fields are
retained by stable identity, and graph layout lives separately. Export a fresh workbook
after merging. No background document overwrite or cloud sync.

Baselines stay versioned under `Editor/DialogueExchange/<asset-guid>/Bases`.
`Tools > Astra > Dialogue > Purge Exchange Baselines` lists the baselines older than
90 days and deletes them after confirmation. A workbook exported from a purged baseline
can no longer merge automatically; import it as a new conversation instead.

Supported extension parameters: string, bool, int, float, double and enums, including
private `[SerializeField]` members declared on abstract base classes of the extension.
Unity object fields remain local and are preserved for existing extensions of the
same type. New extensions requiring Unity object fields must be configured in Unity.
Nested custom parameter objects require a future codec; export refuses them.
Missing extension types/version mismatches block import without deleting the workbook.
Renaming a C# managed-reference type still needs Unity's `MovedFrom` migration;
stable exchange IDs alone do not migrate serialized Unity assets.

The codec writes/reads standard OOXML using .NET XML/ZIP libraries in the Editor.
Native Excel and Google Sheets interoperability must be qualified separately from
the automated codec tests. Word, Ink and Yarn import are not part of this candidate.

## Presentation and inputs

`DialoguePresenter` uses UI Toolkit with a PanelSettings asset whose theme is the
included `CozyDialogue.tss`. That stylesheet holds the layout: margins, radii and sizes
of `#dialogue-overlay`, `#dialogue-card`, `#dialogue-speaker`, `#dialogue-text-scroll`,
`#dialogue-continue` and the `.dialogue-answer` buttons. A PanelSettings asset that uses
another theme must import or copy these rules. Assign a `DialogueThemeAsset` for colors,
type size, text speed, instant text, reduced motion and optional synthesized character
syllables. Text reveals at `CharactersPerSecond` even above the frame rate.

The continue, reveal, choose and busy texts are resolved through `IDialogueTextResolver`
with the keys `ui.continue`, `ui.reveal`, `ui.choose` and `ui.busy`; the theme asset holds
their editable fallbacks (French in the demo). A narrated line shows no name label, in
the game and in the studio preview. `DialogueRunner` warns when its `ContextProvider`
does not implement `IDialogueContextProvider`.
The artwork and syllables in the orchard are original geometric/synthetic assets.

Pointer and navigation events are handled by UI Toolkit. Configure the host's UI
input actions when using the Input System or mixing UI Toolkit with uGUI. This
candidate does not alter a consumer's input settings or install input packages.
The sample is render-pipeline independent; graphics compatibility is only claimed
for the environments actually listed in the validation report.

## Content Hub and updates

The local pack ID is `astra.dialogue`, installed under
`Assets/AstraContent/astra.dialogue`. Game conversations, characters, conditions and
personalized themes belong outside that folder. Do not import a second copy in an
author project already containing the same GUIDs.

Editor, exchange, presentation and demo assemblies are included; author tests and
Hub qualification scripts are external. UI Toolkit, UI, JSON serialization, IMGUI,
audio and image conversion modules are declared prerequisites. No render pipeline
or optional Astra package is installed by the Hub.

Pack updates preserve GUIDs; schema migrations of game-authored content are separate
operations. Removing a pack with referenced scripts/assets is blocked by Hub checks.
Keep receipts and author .meta files in version control.

## Qualification and current scope

Tests cover execution, conditions, cancellation, checkpoints, serialized extensions,
XLSX round trips, field conflicts, deleted records, stale plans, Unity reference
preservation, port-aware validation, layout side effects, per-sheet identities, import
previews, a 2 000-line workbook, trimmed links and generated Ids, inherited extension
fields, recovery retention, baseline purge and character naming. PlayMode tests cover
text revelation, navigation and lifecycle.
See the repository's `Documentation/Astra/ContentHub/Dialogue/README.md` for measured
results and isolated Hub commands.

This is a local 0.1.2 candidate. Automated tests do not establish large-team editing
usability, complete localization, native spreadsheet compatibility or Windows support.
Code, demo shapes and synthesized syllables are distributed under the MIT License; see
`LICENSES/LICENSE.txt`. The pack is published in the public Astra Content catalogue.
