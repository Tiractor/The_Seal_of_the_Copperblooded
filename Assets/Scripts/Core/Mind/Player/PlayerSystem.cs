using Core.EntityStatuses;
using Core.Events;
using Core.Roleplay;
using Core.UI;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Core.Mind.Player
{
    public class PlayerSystem : ComponentSystem
    {
        public static PlayerComponent _player { get; private set; }
        public override void Initialize()
        {
            Subscribe<PlayerComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<PlayerComponent, DamageEvent>(OnDamage);
            Subscribe<PlayerComponent, DeathEvent>(OnDeath);
            Subscribe<PlayerComponent, PrimaryAttackEvent>(OnPrimaryAttack);
            Subscribe<PlayerComponent, InventorySwitchEvent>(OnInventory);
        }
        private void OnPrimaryAttack(PlayerComponent component, PrimaryAttackEvent args)
        {
            if (component.Statuses.Any(s => s is PrimaryAttackCooldown)) return;
            var Targets = AttackSystem.SplashAttack(component.transform, component.PrimaryAttack.Range);
            foreach (var target in Targets)
            {
                if (target == null) continue;
                TriggerEvent(component.PrimaryAttack, new AttackEvent(target));
            }
            foreach (var eff in component.PrimaryAttack._selfEffects)
            {
                eff.Effect(component);
            }
        }
        private void OnDamage(PlayerComponent component, DamageEvent args)
        {
            TriggerEvent(new UpdateDisplayEvent(Core.UI.Display.Hitpoints));
        }
        private void OnInventory(PlayerComponent component, InventorySwitchEvent args)
        {
            var bol = StatsDisplaySystem.CM.gameObject.active;
            StatsDisplaySystem.CM.gameObject.SetActive(!bol);
            if (bol) Cursor.lockState = CursorLockMode.Locked;
            else Cursor.lockState = CursorLockMode.None;

        }
        private void OnComponentInit(PlayerComponent component, ComponentInitEvent args)
        {
            _player = component;
        }
        private void OnDeath(PlayerComponent component, DeathEvent args)
        {
            Lose();
        }
        private void Lose()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
