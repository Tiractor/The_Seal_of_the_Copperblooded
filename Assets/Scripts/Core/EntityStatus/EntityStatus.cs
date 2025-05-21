using Core.EntityEffects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.EntityStatuses
{
    [Serializable]
    public abstract class EntityStatus
    {
        protected float MaxTime = -1;
        public float Time = -1;
        public bool IsNotDisplayed = true;
        public Sprite icon;
        public virtual HashSet<EntityEffect> SecondEffect() { return null; }
        public virtual HashSet<EntityEffect> TickEffect() { return null; }

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
        public float TimeProgress()
        {
            return MaxTime != -1 ? Time / MaxTime : -1;
        }
        public string strTimeProgress()
        {
            return (int)Time/60+ ":"+Time%60;
        }
    }
}