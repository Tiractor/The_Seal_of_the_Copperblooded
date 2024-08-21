using UnityEngine;

namespace core.events
{
    /// <summary>
    ///     Base event interaction
    /// </summary>
    public abstract class IEvent
    {
    }

    /// <summary>
    ///     After all Subscribe
    /// </summary>
    public class ComponentInit : EntityEvent
    {
        EventComponent Component;
        public ComponentInit(EventComponent component) 
        {
            Component = component;
        }
        public ComponentInit(GameObject initiator, EventComponent component)
        {
            Component = component;
            Initiator = initiator;
        }

    }

    /// <summary>
    ///     Event which get started from Entity
    /// </summary>
    public class EntityEvent : IEvent
    {
#nullable enable
        public GameObject? Initiator { get; set; }
#nullable disable
        public EntityEvent(GameObject initiator)
        {
            Initiator = initiator;
        }
        public EntityEvent()
        {
        }
    }


}