using Core.EntityEffects;
using Core.Roleplay;
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
        public PrimaryAttackCooldown() { MaxTime = 10; }
       // public PrimaryAttackCooldown(float time) { MaxTime = time; }
        public override HashSet<EntityEffect> SecondEffect() 
        {
            return null;
        }
    }
}