using Core.Roleplay.End;
using System;

namespace Core.EntityEffects
{
    [Serializable]
    public class SwitchGameStateEffect : EntityEffect
    {
        public GameState New;
        public override void Effect<T>(T component)
        {
            ComponentSystem.TriggerEvent(new SwitchGameStateEvent(New));
        }
    }
}