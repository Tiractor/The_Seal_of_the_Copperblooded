using Core.EntityEffects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.EntityStatuses
{
    [Serializable]
    public abstract class EntityStatus
    {
        private float MaxTime;
        private float Time = -1;
        private Sprite icon;
        public virtual HashSet<EntityEffect> SecondEffect() { TimeGoing(false); return null; }
        public virtual HashSet<EntityEffect> TickEffect() { TimeGoing(true); return null; }

        protected EntityEffect TimeGoing(bool IsTick)
        {
            if (MaxTime == -1) return null;
            if (Time == -1) Time = MaxTime;
            if (IsTick) Time -= 0.1f;
            else Time -= 1;
            if (Time < 0)
            {
                var eff = new NeutralizeEffect(this);
                return eff;
            }
            return null;
        }
    }
}