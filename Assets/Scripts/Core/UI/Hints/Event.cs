using Core.Events;

namespace Core.UI.Hint
{
    public class ShowHintEvent : ComponentEvent
    {
        public HintData data;
        public ShowHintEvent(HintData Data)
        {
            this.data = Data;
        }
    }
}