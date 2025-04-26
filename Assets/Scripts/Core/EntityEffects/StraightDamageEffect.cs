using System;
using Core.Roleplay;

namespace Core.EntityEffects
{
    [Serializable]
    public class StraightDamageEffect : EntityEffect
    {

        public Damage[] _damage;
        public override void Effect<T>(T component)
        {
            var Damage = new DamageSpecifier();

            Damage.Add(_damage);

            ComponentSystem.TriggerEvent(component, new DamageEvent(Damage));
        }
    }
}