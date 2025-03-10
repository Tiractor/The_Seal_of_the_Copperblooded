using Core.Roleplay;
using System;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public class DamageEffect : EntityEffect
    {
        [SerializeField] public DamageSpecifier damage = new();
        public override void Effect<T>(T component)
        {
            component.Damage.Add(damage);
            ComponentSystem.TriggerEvent(component, new DamageEvent());
            if (component.DamageThreshold <= component.Damage.GetTotal()) 
                ComponentSystem.TriggerEvent(component, new DeathEvent());
            
        }
    }
}