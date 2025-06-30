using System;
using Core.EntityEffects;

namespace Core.Sounds
{
    [Serializable]
    public class SoundEffect : EntityEffect
    {
        public SubtitleData Sound;
        public override void Effect<T>(T component)
        {
            if(Sound == null || component == null) return;
            ComponentSystem.TriggerEvent(new NewSoundEvent(Sound, component.gameObject));
        }
    }
}