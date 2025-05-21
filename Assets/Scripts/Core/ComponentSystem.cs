using Core.Events;
using System;
using UnityEngine;

namespace Core
{
    public abstract class ComponentSystem
    {
        public abstract void Initialize();
        /// <summary>
        ///     Trigger every Second, or 10 Ticks
        /// </summary>
        public virtual void SecondUpdate() { }

        /// <summary>
        ///     Trigger every 0.1 Second, or 1 Ticks
        /// </summary>
        public virtual void TickUpdate() { }


        /// <summary>
        ///     When TEvent triggered on GameObject with TComponent will be invoke Handler
        /// </summary>
        protected static void Subscribe<TComponent, TEvent>(Action<TComponent, TEvent> handler)
                where TEvent : IEvent
                where TComponent : EventComponent
        {
            EventSystem.Subscribe<TComponent, TEvent>(handler);
        }
        protected static void Subscribe<TEvent>(Action<TEvent> handler)
                where TEvent : SimpleEvent
        {
            EventSystem.GlobalSubscribe<TEvent>(handler);
        }
        protected static void Unsubscribe<TComponent, TEvent>(Action<TComponent, TEvent> handler)
            where TEvent : IEvent
            where TComponent : EventComponent
        {
            EventSystem.Unsubscribe<TComponent, TEvent>(handler);
        }

        /// <summary>
        ///     Trigger Global Event
        /// </summary>
        public static void TriggerEvent<T>(T eventArgs)
            where T : SimpleEvent
        {
            EventSystem.TriggerEvent(eventArgs);
        }
        /// <summary>
        ///     Trigger EntityEvent eventArgs with GameObject target 
        /// </summary>
        public static void TriggerEvent<T>(GameObject target, T eventArgs) where T : ComponentEvent
        {
            eventArgs.Initiator = target;
            EventSystem.TriggerEvent(eventArgs);
        }

        /// <summary>
        ///     Trigger EntityEvent eventArgs with EntityComponent target 
        /// </summary>
        public static void TriggerEvent<TComponent, TEvent>(TComponent target, TEvent eventArgs) 
            where TEvent : ComponentEvent
            where TComponent : EventComponent
        {
            eventArgs.Initiator = target.gameObject;
            EventSystem.TriggerTargetComponentEvent(target, eventArgs);
        }

    }
}