using Core.Events;
using Core.Roleplay;
using Core.UI;


namespace Core.Mind.Player
{
    public class PlayerSystem : ComponentSystem
    {
        public static PlayerComponent _player { get; private set; }
        public override void Initialize()
        {
            Subscribe<PlayerComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<PlayerComponent, DamageEvent>(OnDamage);
            Subscribe<PlayerComponent, PrimaryAttackEvent>(OnPrimaryAttack);
            Subscribe<PlayerComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<PlayerComponent, ComponentInitEvent>(OnComponentInit);
        }
        private void OnPrimaryAttack(PlayerComponent component, PrimaryAttackEvent args)
        {
            var Targets = AttackSystem.SplashAttack(component.transform, component.PrimaryAttack.Range);
            foreach (var target in Targets)
            {
                if (target == null) continue;
                TriggerEvent(component.PrimaryAttack, new AttackEvent(target));
            }
        }
        private void OnDamage(PlayerComponent component, DamageEvent args)
        {
            TriggerEvent(new UpdateDisplayEvent(Display.Hitpoints));
        }

        private void OnComponentInit(PlayerComponent component, ComponentInitEvent args)
        {
            _player = component;
        }
    }
}
