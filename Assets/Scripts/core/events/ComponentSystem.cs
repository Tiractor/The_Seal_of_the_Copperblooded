using core.events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComponentSystem
{
    public abstract void Initialize();
    protected static void Subscribe<TComponent, TEvent>(Action<TComponent, TEvent> handler)
            where TEvent : IEvent
            where TComponent : EventComponent
    {
        EventSystem.Subscribe<TComponent, TEvent>(handler);
    }
    protected static void Unsubscribe<TComponent, TEvent>(Action<TComponent, TEvent> handler)
        where TEvent : IEvent
        where TComponent : EventComponent
    {
        EventSystem.Unsubscribe<TComponent, TEvent>(handler);
    }
    protected static void TriggerEvent<T>(EventComponent component, T eventArgs) where T : EntityEvent
    {
        EventSystem.TriggerEvent(eventArgs);
    }
    protected static void TriggerEvent<T>(GameObject Target, T eventArgs) where T : EntityEvent
    {
        eventArgs.Initiator = Target;
        EventSystem.TriggerEvent(eventArgs);
    }

}
