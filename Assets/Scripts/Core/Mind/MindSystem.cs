using Core.Events;
using Core.Roleplay;
using Core.EntityStatuses;
using Core.Mind.Player;

namespace Core.Mind
{
    public class MindSystem : ComponentSystem
    {
        public override void Initialize()
        {
            Subscribe<MindComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<MindComponent, DamageEvent>(OnDamage);
            Subscribe<MindComponent, DeathEvent>(OnDeath);

           /* Subscribe<MindComponent, PrimaryAttackEvent>(PrimaryAttack);
            Subscribe<MindComponent, SecondaryAttackEvent>(SecondaryAttack);
            Subscribe<MindComponent, TertiaryAttackEvent>(TertiaryAttack);*/

        }
        void OnComponentInit(MindComponent component, ComponentInitEvent args)
        {
            Logger.Info(component.gameObject.name);
            foreach (var stat in component.Statuses)
            {
                Logger.Info(stat.GetType().Name);
            }
        }
        void PrimaryAttack(MindComponent component, PrimaryAttackEvent args)
        {
            
        }
        void SecondaryAttack(MindComponent component, SecondaryAttackEvent args)
        {

        }
        void TertiaryAttack(MindComponent component, TertiaryAttackEvent args)
        {

        }


        void OnDamage(MindComponent component, DamageEvent args)
        {
        }
        void OnDeath(MindComponent component, DeathEvent args)
        {
            Logger.Warn("Unit is Dead!");
        }
    }
}