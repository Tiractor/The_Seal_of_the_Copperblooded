using Core.Events;

namespace Core.Roleplay
{
    /// <summary>
    ///     When Entity get Damage
    /// </summary>
    public class DamageEvent : ComponentEvent 
    {
        public DamageSpecifier Damage;
        public DamageEvent(DamageSpecifier damage) 
        {
            Damage = damage;
        }

    }

}