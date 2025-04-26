using Core.Events;
using Core.Roleplay;


namespace Core.Mind.Player
{
    public class PlayerSystem : ComponentSystem
    {
        public static PlayerComponent _player { get; private set; }
        public override void Initialize()
        {
            Subscribe<PlayerComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<PlayerComponent, PrimaryAttackEvent>(OnPrimaryAttack);
            Subscribe<PlayerComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<PlayerComponent, ComponentInitEvent>(OnComponentInit);
        }
        private void OnPrimaryAttack(PlayerComponent component, PrimaryAttackEvent args)
        {
            var Targets = AttackSystem.SplashAttack(component.transform);
            foreach (var target in Targets)
                TriggerEvent(component.PrimaryAttack, new AttackEvent(target));
        }


        private void OnComponentInit(PlayerComponent component, ComponentInitEvent args)
        {
            _player = component;
        }
    }
}
