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
        public float Time = -2;
        public bool IsNotDisplayed = true;
        [HideInInspector] public virtual Sprite icon { get; protected set; }
        public virtual HashSet<EntityEffect> SecondEffect() { return null; }
        public virtual HashSet<EntityEffect> TickEffect() { return null; }
            
        protected EntityEffect TimeGoing(bool IsTick)
        {
            if (MaxTime == -1) return null;
            if (Time == -2) Time = MaxTime;
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
            return (int)Time/60+ ":"+ Math.Round((Time%60), 0);
        }
    }
}