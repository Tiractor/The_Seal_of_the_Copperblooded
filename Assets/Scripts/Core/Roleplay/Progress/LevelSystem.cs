using Core.Collide;
using UnityEngine;

namespace Core.Roleplay.Progress { 
    public class LevelSystem : ComponentSystem
    {
        [SerializeReference]public GameObject ExpObject;
        public override void Initialize()
        {
            Subscribe<LevelComponent, DeathEvent>(OnDeath);
            Subscribe<ExperienceComponent, CollideEvent>(OnCollide);
        }
        private void OnDeath(LevelComponent component, DeathEvent args)
        {
            ExpObject.GetComponent<ExperienceComponent>().Count = component.experience + component.level * 3;
            GameObject.Instantiate(ExpObject, component.transform);
        }
        private void OnCollide(ExperienceComponent component, CollideEvent args)
        {
            args.With.TryGetComponent<LevelComponent>(out var comp);
            if (comp == null) return;
            comp.experience += component.Count;
            while(comp.experience >= comp.nextlvlexp)
            {
                comp.experience -= comp.nextlvlexp;
                comp.level++;
                comp.nextlvlexp += comp.nextlvlexp / 2;
            }
            GameObject.Destroy(args.With.gameObject);
        }
    }
}