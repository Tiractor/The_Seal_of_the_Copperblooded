using Core.EntityEffects;
using Core.Roleplay;
using System;
using System.Collections.Generic;

namespace Core.EntityStatuses
{
    [Serializable]
    public class Poisoned : EntityStatus
    {
        public override HashSet<EntityEffect> SecondEffect() 
        {
            var effects = new HashSet<EntityEffect>();
            effects.Add(TimeGoing(false));

            var damageEffect = new DamageEffect();
            damageEffect.damage.Add(BiologicDamage.Poison, 1);
            effects.Add(damageEffect);

            return effects;
        }
    }
}