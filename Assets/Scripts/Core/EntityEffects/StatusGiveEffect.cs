using Core.EntityStatuses;
using System;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public class StatusGiveEffect : EntityEffect
    {
        
        [SerializeReference] public EntityStatus target = new Fired();
        public override void Effect<T>(T component)
        {
            component.Statuses.Add(target);
        }
    }
}