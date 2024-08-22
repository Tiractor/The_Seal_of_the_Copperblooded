using Core.Events;
using Core.EntityStatuses;

namespace Core.Roleplay
{
    public class UnitSystem : EntitySystem
    {
        public override void Initialize()
        {
            base.Initialize();
            Subscribe<UnitComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<UnitComponent, DamageEvent>(OnDamage);
        }
        public override void SecondUpdate()
        {
        }
        void OnComponentInit(UnitComponent component, ComponentInitEvent args)
        {
            Logger.Info(component.gameObject.name);
            component.Statuses.Add(new Poisoned());
            foreach (var stat in component.Statuses)
            {
                Logger.Info(stat.GetType().Name);
            }
        }

        void OnDamage(UnitComponent component, DamageEvent args)
        {
            Logger.Info(component.Damage.DamageDict);
        }
    }
}