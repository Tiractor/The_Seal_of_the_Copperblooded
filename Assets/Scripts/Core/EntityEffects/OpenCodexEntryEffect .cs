using System;
using Core.Roleplay.Inventory;
using Core.UI.Codex;

namespace Core.EntityEffects
{
    [Serializable]
    public class OpenCodexEntryEffect : EntityEffect
    {
        
       public CodexEntry? target;
        public override void Effect<T>(T component)
        {
            ComponentSystem.TriggerEvent(new UnlockCodexEntryEvent(target));
        }
        public OpenCodexEntryEffect(CodexEntry Target)
        {
            target = Target;
        }
        public OpenCodexEntryEffect()
        {
            target = null;
        }
    }
}