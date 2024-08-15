using System;
using System.ComponentModel.Design;
using UnityEngine;

namespace core.events
{
    /// <summary>
    ///     Base class for event-use objects
    /// </summary>
    public abstract class EventComponent : MonoBehaviour
    {
        protected static void Subscribe<TEvent>(EventComponent component, Action<EventComponent, TEvent> handler)
            where TEvent : IEvent
        { 
            EventSystem.Subscribe<TEvent>(component, handler);
        }
        protected static void Unsubscribe<TEvent>(EventComponent component, Action<EventComponent, TEvent> handler)
            where TEvent : IEvent
        {
            EventSystem.Unsubscribe<TEvent>(component, handler);
        }
        protected void TriggerEvent<T>(EventComponent component, T eventArgs) where T : EntityEvent
        {
            eventArgs.Initiator = this.gameObject;
            EventSystem.TriggerEvent(component, eventArgs);
        }
    }
}