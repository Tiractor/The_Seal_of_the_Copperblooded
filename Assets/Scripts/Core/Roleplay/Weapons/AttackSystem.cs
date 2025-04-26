using Core.Events;
using Core.Mind;
using Core.Roleplay.Attack;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Roleplay
{
    public class AttackSystem : ComponentSystem
    {
        public override void Initialize()
        {
            Subscribe<WeaponComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<WeaponComponent, AttackEvent>(OnAttack);
        }
        void OnComponentInit(WeaponComponent component, ComponentInitEvent args)
        {
            Logger.Info(component.gameObject.name);
        }
        static public List<MindComponent> SplashAttack(Transform Who, float attackRadius = 2f)
        {
            LayerMask enemyLayer = LayerMask.GetMask("Enemy");
            List<MindComponent> Targets = new List<MindComponent>();
            Collider[] hitEnemies = Physics.OverlapSphere(Who.position + Who.forward, attackRadius, enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                Logger.Info("Попали во врага: " + enemy.name);
                var target = enemy.GetComponent<MindComponent>();
                if (target == null) enemy.GetComponentInParent<MindComponent>();
                Targets.Add(target);
            }
            return Targets;
        }
        void OnAttack(WeaponComponent component, AttackEvent args)
        {
            Logger.Tech(component.gameObject.name);
            foreach(var eff in component._weaponEffects)
            {
                eff.Effect(args.Target);
            }
        }
    }
}