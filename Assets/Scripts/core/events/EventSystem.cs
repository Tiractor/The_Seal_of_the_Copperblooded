using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace core.events
{
    /// <summary>
    ///     Base class which will be control interaction
    /// </summary>
    public static class EventSystem
    {
        private struct EventSearch
        {
            public Type EventType;
            public EventComponent Target;

            public EventSearch(Type eventType, EventComponent target)
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

        public static void Subscribe<TEvent>(EventComponent component, Action<EventComponent, TEvent> handler)
            where TEvent : IEvent
        {
            var key = new EventSearch(typeof(TEvent), component);

            if (_eventHandlers.ContainsKey(key))
            {
                _eventHandlers[key] = Delegate.Combine(_eventHandlers[key], handler);
            }
            else
            {
                _eventHandlers[key] = handler;
            }
        }

        public static void Unsubscribe<TEvent>(EventComponent component, Action<EventComponent, TEvent> handler)
            where TEvent : IEvent
        {
            var key = new EventSearch(typeof(TEvent), component);

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

        public static void TriggerEvent<TEvent>(EventComponent component, TEvent eventArgs)
            where TEvent : IEvent
        {
            var key = new EventSearch(typeof(TEvent), component);

            if (_eventHandlers.TryGetValue(key, out var del))
            {
                var action = del as Action<EventComponent, TEvent>;
                action?.Invoke(component, eventArgs);
            }
        }

    }
}