using Core.Events;

namespace Core.UI.Codex
{
    public class CodexEntryComponent : EventComponent
    {
        public CodexEntry data;
        public Switch_Button_UI button;
        private void Awake()
        {
            if(button == null) button = GetComponent<Switch_Button_UI>();
            if(data != null) button.Text = data.entryName;
            button.CheckPressed = true;
        }
        public void Refresh()
        {
            button.Text = data.entryName;
            button.Refresh();
        }
        public void Open()
        {
            EventSystem.TriggerEvent(new OpenCodexEntryEvent(data));
        }
        public void Close()
        {
            EventSystem.TriggerEvent(new OpenCodexEntryEvent(null));
        }
    }
}
