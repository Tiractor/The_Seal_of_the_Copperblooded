using Core.EntityStatuses;
using System;
using System.Linq;
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

            foreach (var status in component.Statuses.Where(status => status.GetType() == n).ToList())
            {
                status.Time = 0;
                component.Statuses.Remove(status);
            }
            Logger.Tech(n.Name);
        }
        public NeutralizeEffect(EntityStatus Target)
        {
            target = Target;
        }
        public NeutralizeEffect()
        {
            target = new Fired();
        }
    }
}