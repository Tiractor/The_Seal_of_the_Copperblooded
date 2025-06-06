using Core.EntityStatuses;
using System;
using System.Linq;
using UnityEngine;
using Core.Roleplay.Inventory;
using Core.Roleplay;

namespace Core.EntityEffects
{
    [Serializable]
    public class GiveItemEffect : EntityEffect
    {
        
       public SlotData? target;
        public override void Effect<T>(T component)
        {
            ComponentSystem.TriggerEvent(component.Inventory, new AddItemEvent(target));
        }
        public GiveItemEffect(SlotData Target)
        {
            target = Target;
        }
        public GiveItemEffect()
        {
            target = GameManager.instance?.Prefabs.ItemNull;
        }
    }
}