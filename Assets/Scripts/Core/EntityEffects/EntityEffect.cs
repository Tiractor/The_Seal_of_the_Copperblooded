using UnityEngine;

namespace Core.EntityEffects
{
    public abstract class EntityEffect
    {
        public virtual void Effect(GameObject Target) { }
        public virtual void Effect<T>(T Target) where T : EntityComponent { }
    }
}