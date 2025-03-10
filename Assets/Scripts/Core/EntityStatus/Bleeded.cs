using Core.EntityEffects;
using Core.Roleplay;
using System.Collections.Generic;

namespace Core.EntityStatuses
{
    public class Bleeded : EntityStatus
    {
        public override HashSet<EntityEffect> SecondEffect() 
        { 
            var effects = new HashSet<EntityEffect>();
            var damageEffect = new DamageEffect();
            damageEffect.damage.Add(BiologicDamage.Bloodloss, 1);
            damageEffect.damage.Add(BiologicDamage.Asphyxiation, 0.2f * damageEffect.damage.GetSpecific(BiologicDamage.Bloodloss));
            effects.Add(damageEffect);
            return effects;
        }
    }
}