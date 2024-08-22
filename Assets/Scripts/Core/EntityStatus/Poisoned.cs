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
            var damage = new DamageEffect();
            damage.damage.DamageDict.Add(BiologicDamage.Poison.ToString(), 1);
            effects.Add(damage);
            return effects;
        }
    }
}