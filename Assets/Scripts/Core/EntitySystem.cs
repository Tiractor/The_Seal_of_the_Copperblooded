using Core.EntityStatuses;
using Core.Events;
using Core.Mind.Player;
using Core.Roleplay;
using Core.Roleplay.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class EntitySystem : ComponentSystem
    {
        private HashSet<EntityComponent> _entities = new();
        public override void Initialize()
        {
            Subscribe<EntityComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<EntityComponent, DamageEvent>(OnDamage);
        }
        public override void SecondUpdate()
        {
            foreach (var entity in _entities) 
            {
                var Temp = entity.Statuses.ToList();
                foreach (var status in Temp)
                {
                    if (status.IsNotDisplayed && entity is PlayerComponent player && status.TimeProgress() != -1)
                    {
                        TriggerEvent(player, new DisplayStatusEvent(status));
                        status.IsNotDisplayed = false;
                    }
                    var effects = status.SecondEffect();
                    if (effects == null || effects.Count == 0) continue;
                    foreach (var effect in effects)
                    {
                        if (entity != null && effect != null) effect.Effect(entity);
                    }
                }
            }
        }
        public override void TickUpdate()
        {
            base.TickUpdate();
            foreach (var entity in _entities)
            {
                foreach (var status in entity.Statuses)
                {
                    var effects = status.TickEffect();
                    if (effects == null) continue;
                    foreach (var effect in effects)
                    {
                        effect.Effect(entity);
                    }
                }
            }
        }
        private void OnDamage(EntityComponent component, DamageEvent args)
        {
            var dat = args.Damage * component.Resistance;
            component.Damage.Add(dat);
            if (component.DamageThreshold <= component.Damage.GetTotal()) { 
                component.TryGetComponent<LevelComponent>(out var progress);
                if (progress != null) TriggerEvent(component, new DeathEvent(progress));
                else GameObject.Destroy(component.gameObject);
            }
            Logger.Info(component.Damage.Display());
        }
        private void OnComponentInit(EntityComponent component, ComponentInitEvent args) 
        {
            _entities.Add(component);
        }

    }
}