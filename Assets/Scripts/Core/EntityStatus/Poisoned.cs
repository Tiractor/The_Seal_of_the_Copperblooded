using Core.EntityEffects;
using Core.Roleplay;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.EntityStatuses
{
    [Serializable]
    public class Poisoned : EntityStatus
    {
        private Sprite _icon;
        public override Sprite icon => _icon ??= GameManager.instance?.Prefabs.Poisoned;
        public Poisoned()
        {
            MaxTime = 10;
            Time = MaxTime;
        }
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