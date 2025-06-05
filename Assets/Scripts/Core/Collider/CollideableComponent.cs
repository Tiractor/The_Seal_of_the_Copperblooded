using Core.Events;
using UnityEngine;
namespace Core.Collide
{
    [RequireComponent(typeof(Collider))]
    public abstract class CollideableComponent : EventComponent
    {
        void OnCollisionEnter(Collision collision)
        {
            Logger.Tech("Hit");
            collision.collider.TryGetComponent<EntityComponent>(out var Comp);

            ComponentSystem.TriggerEvent(this, new CollideEvent(this, Comp));
        }
    }
}