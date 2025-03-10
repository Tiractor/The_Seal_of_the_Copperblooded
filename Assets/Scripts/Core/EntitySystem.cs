using Core.Events;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class EntitySystem : ComponentSystem
    {
        private HashSet<EntityComponent> _entities = new();
        public override void Initialize()
        {
            Subscribe<EntityComponent, ComponentInitEvent>(OnComponentInit);
        }
        public override void SecondUpdate()
        {
            base.SecondUpdate();
            foreach (var entity in _entities) 
            {
                var Temp = entity.Statuses.ToList();
                foreach (var status in Temp)
                {
                    var effects = status.SecondEffect();
                    if (effects == null) continue;
                    foreach (var effect in effects)
                    {
                        effect.Effect(entity);
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
        private void OnComponentInit(EntityComponent component, ComponentInitEvent args) 
        {
            _entities.Add(component);
        }

    }
}