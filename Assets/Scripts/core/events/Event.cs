using UnityEngine;

namespace Core.Events
{
    /// <summary>
    ///     Base event interaction
    /// </summary>
    public interface IEvent
    {
    }

    /// <summary>
    ///     After all Subscribe
    /// </summary>
    public class ComponentInitEvent : EntityEvent
    {
        EventComponent Component;
        public ComponentInitEvent(EventComponent component) 
        {
            Component = component;
        }
        public ComponentInitEvent(GameObject initiator, EventComponent component)
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
    /// <summary>
    ///     Event for Global using
    /// </summary>
    public class SimpleEvent : IEvent
    {
        public SimpleEvent()
        {
        }
    }

}