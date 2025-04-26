using Core.Mind.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Core.Events
{
    /// <summary>
    ///     Base class which will be control interaction
    /// </summary>
    public static class EventSystem
    {
        private struct EventSearch
        {
            public Type EventType;
            public Type Target;

            public EventSearch(Type eventType, Type target)
            {
                EventType = eventType;
                Target = target;
            }

            // Переопределение Equals для корректного сравнения в словаре
            public override bool Equals(object obj)
            {
                if (!(obj is EventSearch other)) return false;
                return EventType == other.EventType && Target == other.Target;
            }

            // Переопределение GetHashCode для использования структуры в качестве ключа словаря
            public override int GetHashCode()
            {
                return EventType.GetHashCode() ^ Target.GetHashCode();
            }
        }

        private static Dictionary<EventSearch, Delegate> _eventHandlers = new Dictionary<EventSearch, Delegate>();
        private static Dictionary<Type, Delegate> _globalEventHandlers = new Dictionary<Type, Delegate>();

        public static void Subscribe<TComponent, TEvent>(Action<TComponent, TEvent> handler)
            where TEvent : IEvent
            where TComponent : EventComponent
        {
            var key = new EventSearch(typeof(TEvent), typeof(TComponent));
            if (GameManager.instance.Debugging) Logger.Tech($"Происходит подписка: {key}");
            if (_eventHandlers.ContainsKey(key))
            {
                _eventHandlers[key] = Delegate.Combine(_eventHandlers[key], handler);
            }
            else
            {
                _eventHandlers[key] = handler;
            }
        }
        public static void GlobalSubscribe<TEvent>(Action<TEvent> handler)
            where TEvent : IEvent
        {
            var key = typeof(TEvent);

            if (_globalEventHandlers.ContainsKey(key))
            {
                _globalEventHandlers[key] = Delegate.Combine(_globalEventHandlers[key], handler);
            }
            else
            {
                _globalEventHandlers[key] = handler;
            }
        }

        public static void Unsubscribe<TComponent, TEvent>(Action<TComponent, TEvent> handler)
            where TEvent : IEvent
            where TComponent : EventComponent
        {
            var key = new EventSearch(typeof(TEvent), typeof(TComponent));

            if (_eventHandlers.ContainsKey(key))
            {
                var currentDel = Delegate.Remove(_eventHandlers[key], handler);

                if (currentDel == null)
                {
                    _eventHandlers.Remove(key);
                }
                else
                {
                    _eventHandlers[key] = currentDel;
                }
            }
        }


        public static void TriggerEvent<TEvent>(TEvent eventArgs)
        where TEvent : IEvent
        {
            if (eventArgs is EntityEvent e) TriggerTargetEvent(e);
            else if (eventArgs is SimpleEvent s) TriggerGlobalEvent(s);
        }


        private static void TriggerTargetEvent<TEvent>(TEvent eventArgs)
            where TEvent : EntityEvent
        {
            foreach (EventComponent component in eventArgs.Initiator.GetComponents<EventComponent>()) {
                TriggerTargetComponentEvent(component, eventArgs);
            }
        }
        public static void TriggerTargetComponentEvent<TComponent, TEvent>(TComponent component, TEvent eventArgs)
            where TEvent : EntityEvent
            where TComponent : EventComponent
        {
            var derived = component.GetType();
            if (GameManager.instance.Debugging) Logger.Tech($"Был вызван: {eventArgs} по компоненту {component}");
            while (derived != null)
            {
                var key = new EventSearch(eventArgs.GetType(), derived);
                if (_eventHandlers.TryGetValue(key, out var del))
                {
                    if (GameManager.instance.Debugging) Logger.Tech($"Был найден");
                    del?.DynamicInvoke(component, eventArgs);
                }
                derived = derived.BaseType;
            }
        }
        private static void TriggerGlobalEvent<TEvent>(TEvent eventArgs)
            where TEvent : SimpleEvent
        {
            
            if (_globalEventHandlers.TryGetValue(typeof(TEvent), out var del))
            {
                var action = del as Action<TEvent>;
                action?.Invoke(eventArgs);
            }
        }

    }
}