using Core.Events;

namespace Core.EntityStatuses
{
    public class DisplayStatusEvent : ComponentEvent
    {
        public EntityStatus EntityStatus;
        public DisplayStatusEvent(EntityStatus entityStatus) 
        { 
        EntityStatus = entityStatus;
        }
    }

}
