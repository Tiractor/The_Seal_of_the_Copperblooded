using Core.Events;
using UnityEngine;
namespace Core.Collide
{
    [RequireComponent(typeof(Collider))]
    public abstract class CollideableComponent : EventComponent
    {
        void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent<EntityComponent>(out var Comp);

            ComponentSystem.TriggerEvent(this, new CollideEvent(this, Comp));
        }
    }
}