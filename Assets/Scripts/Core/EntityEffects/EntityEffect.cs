using System;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public abstract class EntityEffect
    {
        public virtual void Effect(GameObject Target) { }
        public virtual void Effect<T>(T Target) where T : EntityComponent { }
    }
}