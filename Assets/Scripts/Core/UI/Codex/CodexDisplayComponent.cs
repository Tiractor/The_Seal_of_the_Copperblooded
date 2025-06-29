using Core.Events;
using TMPro;

namespace Core.UI.Codex
{
    public class CodexDisplayComponent : EventComponent
    {
        public CodexEntry data;
        public TMP_Text Title;
        public TMP_Text Text;
        private void Awake()
        {
            Refresh();
        }
        
        public void Refresh()
        {
            if (data == null)
            {
                Title.text = string.Empty;
                Text.text = string.Empty;
                return;
            }
                Title.text = data.entryName;
            Text.text = data.content;
        }
    }
}
