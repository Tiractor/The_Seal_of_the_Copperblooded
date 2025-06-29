using Core.Events;
using Core.Roleplay.Inventory;
using System.Collections.Generic;
using UnityEngine;
namespace Core.UI.Codex
{
    public class CodexSystem : ComponentSystem
    {
        public HashSet<string> unlockedEntries = new(); // хранит ID открытых записей
        public static CodexComponent codexComponent;
        private CodexDisplayComponent display;
        public override void Initialize()
        {
            Subscribe<UnlockCodexEntryEvent>(OnUnlock);
            Subscribe<OpenCodexEntryEvent>(OnOpenEntry);
            Subscribe<CodexComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<CodexDisplayComponent, ComponentInitEvent>(OnComponentInit);

        }
        private void OnComponentInit(CodexComponent component, ComponentInitEvent args)
        {
            codexComponent = component;
            codexComponent.gameObject.SetActive(false);
        }
        private void OnComponentInit(CodexDisplayComponent component, ComponentInitEvent args)
        {
            display = component;
        }
        private void OnOpenEntry(OpenCodexEntryEvent args)
        {
            if (display == null) return;
            display.data = args.entry;
            display.Refresh();
        }
        private void CreateEntrie(CodexEntry What)
        {
            if (codexComponent == null) return;
            var obj = GameObject.Instantiate(GameManager.instance.Prefabs.EntryButton, codexComponent.Holder.transform);
            obj.TryGetComponent<CodexEntryComponent>(out var cod);
            cod.data = What;
            cod.Refresh();
        }
        private void OnUnlock(UnlockCodexEntryEvent evt)
        {
            if (!unlockedEntries.Contains(evt.entry.entryID))
            {
                unlockedEntries.Add(evt.entry.entryID);
                CreateEntrie(evt.entry);
                Debug.Log($"Ќова€ запись в кодексе: {evt.entry.entryName}");
            }
        }


    }
}