using Core.EntityStatuses;
using System;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public class NeutralizeEffect : EntityEffect
    {
        
        [SerializeReference] public EntityStatus target = new Fired();
        public override void Effect<T>(T component)
        {
            Type n = target.GetType();
            component.Statuses.RemoveWhere(status => status.GetType() == n);
            Logger.Tech(n.Name);
        }
    }
}