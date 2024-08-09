using System;
using System.Collections.Generic;

namespace core.events
{
    /// <summary>
    ///     Base class which will be control interaction
    /// </summary>
    public static class EventSystem 
    {
        private static Dictionary<Type, Delegate> _eventHandlers = new Dictionary<Type, Delegate>();
        public static void Subscribe<T>(Action<T> handler) where T : class
        {
            var type = typeof(T);
            if (_eventHandlers.ContainsKey(type))
            {
                _eventHandlers[type] = Delegate.Combine(_eventHandlers[type], handler);
            }
            else
            {
                _eventHandlers[type] = handler;
            }
        }
        public static void Unsubscribe<T>(Action<T> handler) where T : class
        {
            var type = typeof(T);
            if (_eventHandlers.ContainsKey(type))
            {
                var currentDel = Delegate.Remove(_eventHandlers[type], handler);

                if (currentDel == null)
                {
                    _eventHandlers.Remove(type);
                }
                else
                {
                    _eventHandlers[type] = currentDel;
                }
            }
        }
        public static void TriggerEvent<T>(T eventArgs) where T : IEvent
        {
            var type = typeof(T);
            if (_eventHandlers.TryGetValue(type, out var del))
            {
                var action = del as Action<T>;
                action?.Invoke(eventArgs);
            }
        }
    }
}