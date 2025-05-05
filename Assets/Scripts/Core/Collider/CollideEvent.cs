using Core.Events;

namespace Core.Collide
{
    public class CollideEvent : ComponentEvent
    {

        public CollideableComponent Who;
        public EntityComponent With;
        public CollideEvent(CollideableComponent who, EntityComponent with)
        {
            Who = who;
            With = with;
        }
    }
}