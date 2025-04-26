using Core.Roleplay;

namespace Core.EntityEffects
{
    [HideInCustomInspector]
    public class DamageEffect : EntityEffect
    {
        public DamageSpecifier damage = new();
        public override void Effect<T>(T component)
        {
            ComponentSystem.TriggerEvent(component, new DamageEvent(damage));
        }
    }
}