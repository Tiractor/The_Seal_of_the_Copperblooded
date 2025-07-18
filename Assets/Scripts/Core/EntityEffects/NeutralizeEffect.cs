using Core.EntityStatuses;
using System;
using System.Linq;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public class NeutralizeEffect : EntityEffect
    {
        
        [SerializeReference] public Statuses target;
        public override void Effect<T>(T component)
        {
            Type n = StatusReturner.EnumToStatus(target).GetType();

            foreach (var status in component.Statuses.Where(status => status.GetType() == n).ToList())
            {
                status.Time = 0;
                component.Statuses.Remove(status);
            }
        }
        public NeutralizeEffect(EntityStatus Target)
        {
            target = StatusReturner.StatusToEnum(Target);
        }
        public NeutralizeEffect()
        {
            target = Statuses.Fired;
        }
    }
}