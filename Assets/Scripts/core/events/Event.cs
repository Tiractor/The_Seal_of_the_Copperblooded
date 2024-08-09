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
    public class ComponentInit : IEvent
    {
    }

    /// <summary>
    ///     Event which get started from Entity
    /// </summary>
    public class EntityEvent : IEvent
    {
#nullable enable
        public GameObject? Initiator { get; set; }
#nullable disable
    }


}