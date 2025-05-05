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
    public class ComponentInitEvent : ComponentEvent
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
    ///     After all Subscribe
    /// </summary>
    public class SimpleComponentEvent : ComponentEvent
    {
        EventComponent Component;
        public SimpleComponentEvent(EventComponent component)
        {
            Component = component;
        }
        public SimpleComponentEvent(GameObject initiator, EventComponent component)
        {
            Component = component;
            Initiator = initiator;
        }
    }

    /// <summary>
    ///     Event which get started from Entity
    /// </summary>
    public class ComponentEvent : IEvent
    {
#nullable enable
        public GameObject? Initiator { get; set; }
#nullable disable
        public ComponentEvent(GameObject initiator)
        {
            Initiator = initiator;
        }
        public ComponentEvent()
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