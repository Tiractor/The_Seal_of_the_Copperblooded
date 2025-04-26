using Core.Events;
using Core.Roleplay.Progress;

namespace Core.Roleplay
{
    /// <summary>
    ///     When Damage is overflow DamageThreshold
    /// </summary>
    public class DeathEvent : EntityEvent {
        public LevelComponent Killed;
        public DeathEvent(LevelComponent killed)
        {
            this.Killed = killed;
        }
    }
}