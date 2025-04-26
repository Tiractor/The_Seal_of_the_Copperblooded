using Core.EntityEffects;
using Core.Roleplay;
using System;
using System.Collections.Generic;

namespace Core.EntityStatuses
{
    [Serializable]
    public class Fired : EntityStatus
    {
        public override HashSet<EntityEffect> SecondEffect() 
        { 
            var effects = new HashSet<EntityEffect>();

            var damageEffect = new DamageEffect();
            damageEffect.damage.Add(BurnDamage.Heat, 0.2f);
            effects.Add(damageEffect);

            var neutralizeEffect = new NeutralizeEffect();
            neutralizeEffect.target = new Frosted();
            effects.Add(neutralizeEffect);

            return effects;
        }
    }
}