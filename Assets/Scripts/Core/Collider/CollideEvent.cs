using Core.Events;

namespace Core.Collide
{
    public class CollideEvent : EntityEvent
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