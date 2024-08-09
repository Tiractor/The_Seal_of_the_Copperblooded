using core.events;
using System;
using UnityEngine;

namespace core 
{
    /// <summary>
    ///     Base class for interactable objects
    /// </summary>
    public abstract class Entity : MonoBehaviour
    {
        protected static void Subscribe<T>(Action<T> handler) where T : class
        {
            EventSystem.Subscribe(handler);
        }
        protected static void Unsubscribe<T>(Action<T> handler) where T : class
        {
            EventSystem.Unsubscribe(handler);
        }
        protected void TriggerEvent<T>(T eventArgs) where T : EntityEvent
        {
            eventArgs.Initiator = this.gameObject;
            EventSystem.TriggerEvent(eventArgs);
        }
    }
}