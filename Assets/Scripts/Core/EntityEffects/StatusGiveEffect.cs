using Core.EntityStatuses;
using System;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public class StatusGiveEffect : EntityEffect
    {
        
        [SerializeReference] public Statuses target = Statuses.Fired;
        public override void Effect<T>(T component)
        {
            component.Statuses.Add(StatusReturner.EnumToStatus(target));
            Debug.Log(component + " " + target.ToString());
            component.DisplayStatuses();
        }
    }
}