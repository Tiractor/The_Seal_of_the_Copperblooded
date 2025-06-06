using Core.EntityEffects;
using Core.Roleplay;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.EntityStatuses
{
    [Serializable]
    public class Bleeded : EntityStatus
    {
        private Sprite _icon;
        public override Sprite icon => _icon ??= GameManager.instance?.Prefabs.Bleeded;
        public Bleeded() 
        { 
            MaxTime = 10;
            Time = MaxTime;
        }
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