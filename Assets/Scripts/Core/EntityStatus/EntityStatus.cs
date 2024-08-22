using Core.EntityEffects;
using System;
using System.Collections.Generic;

namespace Core.EntityStatuses
{
    [Serializable]
    public abstract class EntityStatus
    {
        public virtual HashSet<EntityEffect> SecondEffect() { return null; }
        public virtual HashSet<EntityEffect> TickEffect() { return null; }
    }
}