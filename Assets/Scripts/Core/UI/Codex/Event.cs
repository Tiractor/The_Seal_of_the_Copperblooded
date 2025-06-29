using Core.Events;

namespace Core.UI.Codex
{
    public class UnlockCodexEntryEvent : SimpleEvent
    {
        public CodexEntry entry;
        public UnlockCodexEntryEvent(CodexEntry Entry)
        {
            this.entry = Entry;
        }
    }
    public class OpenCodexEntryEvent : SimpleEvent
    {
        public CodexEntry entry;
        public OpenCodexEntryEvent(CodexEntry Entry)
        {
            this.entry = Entry;
        }
    }
}