using Core.EntityEffects;
using Core.Roleplay;
using System.Collections.Generic;

namespace Core.EntityStatuses
{
    public class Poisoned : EntityStatus
    {
        public override HashSet<EntityEffect> SecondEffect() 
        { 
            var effects = new HashSet<EntityEffect>();
            var damageEffect = new DamageEffect();
            damageEffect.damage.Add(BiologicDamage.Poison, 1);
            effects.Add(damageEffect);
            return effects;
        }
    }
}