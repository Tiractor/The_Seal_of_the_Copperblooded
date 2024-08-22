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
            foreach (var cur in damage.DamageDict)
            {
                if (component.Damage.DamageDict.ContainsKey(cur.Key))
                {
                    component.Damage.DamageDict[cur.Key] = component.Damage.DamageDict[cur.Key] + cur.Value;
                }
                else
                {
                    component.Damage.DamageDict[cur.Key] = cur.Value;
                }
            }
            ComponentSystem.TriggerEvent(component, new DamageEvent());
        }
    }
}