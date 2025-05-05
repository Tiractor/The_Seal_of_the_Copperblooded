using Core.Events;
using Core.Mind;
using Core.Roleplay.Attack;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
        static public List<EntityComponent> SplashAttack(Transform Who, float attackRadius = 2f)
        {
            LayerMask enemyLayer = LayerMask.GetMask("Enemy");
            List<EntityComponent> Targets = new List<EntityComponent>();
            Collider[] hitEnemies = Physics.OverlapSphere(Who.position + Who.forward, attackRadius, enemyLayer);

            foreach (var hit in hitEnemies)
            {
                Transform current = hit.transform;
                EntityComponent target = null;
                while (current != null)
                {
                    target = current.GetComponent<EntityComponent>();
                    if (target != null)
                        break;

                    current = current.parent;
                }
                if (target == null)
                {
                    Logger.Warn("Entity not found для " + hit.name);
                    continue;
                }
                Targets.Add(target);
                Logger.Info("Попали во врага: " + target.name);
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