using Core.Collide;
using UnityEngine;

namespace Core.Roleplay.Progress { 
    public class LevelSystem : ComponentSystem
    {
        public override void Initialize()
        {
            Subscribe<LevelComponent, DeathEvent>(OnDeath);
            Subscribe<ExperienceComponent, CollideEvent>(OnCollide);
        }
        private void OnDeath(LevelComponent component, DeathEvent args)
        {
            var pos = component.transform.position;
            pos.y += 1f;
            var temp = GameObject.Instantiate(GameManager.instance.Prefabs.ExpObject, pos, component.transform.rotation, component.transform.parent);
            temp.GetComponent<ExperienceComponent>().Count = component.experience + component.level * 3;
            GameObject.Destroy(component.gameObject); 
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
            GameObject.Destroy(args.Who.gameObject);
        }
    }
}