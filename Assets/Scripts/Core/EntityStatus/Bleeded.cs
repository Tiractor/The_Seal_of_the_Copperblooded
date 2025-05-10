using Core.EntityEffects;
using Core.Roleplay;
using System;
using System.Collections.Generic;

namespace Core.EntityStatuses
{
    [Serializable]
    public class Bleeded : EntityStatus
    {
        public override HashSet<EntityEffect> SecondEffect() 
        { 
            var effects = new HashSet<EntityEffect>();
            effects.Add(TimeGoing(false));

            var damageEffect = new DamageEffect();
            damageEffect.damage.Add(DamageType.Bloodloss, 1);
            damageEffect.damage.Add(BiologicDamage.Asphyxiation, 0.2f * damageEffect.damage.GetSpecific(BiologicDamage.Bloodloss));
            effects.Add(damageEffect);

            return effects;
        }
    }
}