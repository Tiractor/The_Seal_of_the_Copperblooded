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
        protected void TriggerEvent<T>(EventComponent component, T eventArgs) where T : EntityEvent
        {
            eventArgs.Initiator = gameObject;
            EventSystem.TriggerEvent(eventArgs);
        }
        private void Start()
        {
            TriggerEvent(this, new ComponentInit(this));
            
        }
    }
}