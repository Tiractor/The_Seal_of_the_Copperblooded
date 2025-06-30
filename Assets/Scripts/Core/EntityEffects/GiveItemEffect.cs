using System;
using Core.Roleplay.Inventory;

namespace Core.EntityEffects
{
    [Serializable]
    public class GiveItemEffect : EntityEffect
    {
        
       public SlotData? target;
        public override void Effect<T>(T component)
        {
            ComponentSystem.TriggerEvent(component.Inventory, new AddItemEvent(new SlotData(target)));
        }
        public GiveItemEffect(SlotData Target)
        {
            target = Target;
        }
        public GiveItemEffect()
        {
            target = null;
        }
    }
}