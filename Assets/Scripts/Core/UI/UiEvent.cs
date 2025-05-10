using Core.Events;

namespace Core.UI
{
    public class UpdateDisplayEvent : SimpleEvent
    {
        public Display What;
        public UpdateDisplayEvent(Display what)
        {
            this.What = what;
        }
    }
}
