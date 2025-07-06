
using Core.Events;
using Core.Roleplay.Inventory;
using Core.UI.Codex;
using System.Collections.Generic;

namespace Core.UI.Hint
{
    public class HintSystem : ComponentSystem
    {
        public HintComponent hintUI;
        public static AlertComponent codex;
        public static AlertComponent inventory;
        public HashSet<string> shownHints = new();

        public override void Initialize()
        {
            Subscribe<HintComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<AlertComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<HintComponent, ShowHintEvent>(OnShowHint);
            Subscribe<UnlockCodexEntryEvent>(OnUnlock);
            Subscribe<InventoryComponent, AddItemEvent>(NewItem);
        }
        private void NewItem(InventoryComponent component, AddItemEvent args)
        {
            if (inventory == null) return;
            inventory.gameObject.SetActive(true);
        }
        private void OnUnlock(UnlockCodexEntryEvent evt)
        {
            if (codex == null) return;
            if (CodexSystem.unlockedEntries.Contains(evt.entry.entryID)) return;
            codex.gameObject.SetActive(true);
        }
        private void OnComponentInit(HintComponent component, ComponentInitEvent args)
        {
            hintUI = component;
        }
        private void OnComponentInit(AlertComponent component, ComponentInitEvent args)
        {
            component.gameObject.SetActive(false);
            switch (component.Type)
            {
                case Alert.Codex: codex = component; return;
                case Alert.Inventory: inventory = component; return;
                default: return;
            }
        }
        private void OnShowHint(HintComponent component, ShowHintEvent evt)
        {
            if (shownHints.Contains(evt.data.hintId)) return;

            shownHints.Add(evt.data.hintId);
            hintUI.Show(evt.data.text, evt.data.duration);
        }
    }
}
