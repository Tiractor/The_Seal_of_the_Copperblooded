using Core.EntityEffects;
using Core.Roleplay;
using System;
using System.Collections.Generic;

namespace Core.EntityStatuses
{
    [Serializable]
    public class Frosted : EntityStatus
    {
        public override HashSet<EntityEffect> SecondEffect() 
        {
            var effects = new HashSet<EntityEffect>();
            effects.Add(TimeGoing(false));

            var damageEffect = new DamageEffect();
            damageEffect.damage.Add(BurnDamage.Cold, 0.2f);
            effects.Add(damageEffect);

            var neutralizeEffect = new NeutralizeEffect(new Fired());
            effects.Add(neutralizeEffect);

            return effects;
        }
    }
}