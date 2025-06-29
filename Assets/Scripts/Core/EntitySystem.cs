using Core.EntityStatuses;
using Core.Events;
using Core.Mind.NPC;
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
            foreach (var entity in _entities)
            {
                FlashTick(entity.Flash);
                var Temp = entity.Statuses.ToList();
                foreach (var status in Temp)
                {
                    if (status.IsNotDisplayed && entity is PlayerComponent player && status.TimeProgress() != -1)
                    {
                        TriggerEvent(player, new DisplayStatusEvent(status));
                        status.IsNotDisplayed = false;
                    }
                    var effects = status.TickEffect();
                    if (effects == null || effects.Count == 0) continue;
                    foreach (var effect in effects)
                    {
                        if (entity != null && effect != null) effect.Effect(entity);
                    }
                }
            }
        }
        private void FlashTick(DamageFlashComponent component)
        {
            if (!component.isFlashing) return;

            component.timer -= 0.1f;
            if (component.timer <= 0f)
            {
                if (component.targetRenderer != null)
                {
                    component.targetRenderer.material.color = component.originalColor;
                }
                component.isFlashing = false;
            }
        }
        private void OnDamage(EntityComponent component, DamageEvent args)
        {
            var dat = args.Damage * component.Resistance;
            Logger.Warn(component.Resistance.DictDisplay());
            component.Damage.Add(dat);
            if (component.DamageThreshold <= component.Damage.GetTotal()) { 
                component.TryGetComponent<LevelComponent>(out var progress);
                if (progress != null) TriggerEvent(component, new DeathEvent(progress));
                else GameObject.Destroy(component.gameObject);
            }
            Logger.Info(component.Damage.Display());
            OnDamage(component.Flash, args);
        }
        private void OnDamage(DamageFlashComponent component, DamageEvent evt)
        {
            if (component.targetRenderer == null) return;

            var mat = component.targetRenderer.material;

            if (!component.isFlashing)
            {
                component.originalColor = mat.color;
            }

            mat.color = component.flashColor;
            component.timer = component.flashDuration;
            component.isFlashing = true;
        }
        private void OnComponentInit(EntityComponent component, ComponentInitEvent args) 
        {
            _entities.Add(component);
            component.Flash = component.GetComponent<DamageFlashComponent>();
            component.Flash.targetRenderer = component.GetComponent<Renderer>();
            if(component.Flash.targetRenderer == null) component.Flash.targetRenderer = component.GetComponentInChildren<Renderer>();
        }

    }
}