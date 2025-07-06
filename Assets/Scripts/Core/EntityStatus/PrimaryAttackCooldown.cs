using Core.EntityEffects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.EntityStatuses
{
    [Serializable]
    public class PrimaryAttackCooldown : EntityStatus
    {
        private Sprite _icon;
        public override Sprite icon => _icon ??= GameManager.instance?.Prefabs.PrimaryAttack;
        public PrimaryAttackCooldown() { MaxTime = 2; }
        public override HashSet<EntityEffect> TickEffect() 
        {
            var effects = new HashSet<EntityEffect>();
            effects.Add(TimeGoing(true));

            return effects;
        }
    }
}