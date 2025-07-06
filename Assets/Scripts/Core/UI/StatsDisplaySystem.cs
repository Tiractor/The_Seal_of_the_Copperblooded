using Core.EntityStatuses;
using Core.Events;
using Core.Mind.Player;
using Core.Roleplay;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public class StatsDisplaySystem : ComponentSystem
    {
        public static HashSet<StatDisplay> statDisplays = new HashSet<StatDisplay>();
        public static HPDisplayComponent HP;
        public static CharMenuComponent CM;
        public static HashSet<StatusDisplayerComponent> statusDisplayers = new HashSet<StatusDisplayerComponent>();
        public override void Initialize()
        {
            Subscribe<StatDisplay, ComponentInitEvent>(OnComponentInit);
            Subscribe<HPDisplayComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<StatusDisplayerComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<CharMenuComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<PlayerComponent, ComponentInitEvent>(OnDataInit);
            Subscribe<PlayerComponent, DisplayStatusEvent>(NewStatus);
            Subscribe<PlayerComponent, DamageEvent>(UpdateHPDisplay);
            Subscribe<StatDisplay, SimpleComponentEvent>(Refresh);
            Subscribe<UpdateDisplayEvent>(TargetRefresh);
        }
        private void TargetRefresh(UpdateDisplayEvent args)
        {
            foreach (var item in statDisplays)
            {
                if(item.what == args.What)
                    DataRefresh(item);
            }
        }
        private void UpdateHPDisplay(PlayerComponent component, DamageEvent args)
        {
            var health = component.Damage.GetTotal();
            var maxhealth = component.DamageThreshold;
            int stage = GetStageFromHealth(maxhealth-health);
            stage = Mathf.Clamp(stage, 0, HP.healthStages.Length - 1);
            HP.healthBarImage.sprite = HP.healthStages[stage];
        }
        int GetStageFromHealth(float hp, float threshold = 50f)
        {
            for (int i = 0; i < HP.healthStages.Length; i++)
            {
                if (hp >= threshold) 
                {
                    return i;
                }
                    
                threshold /= 2f; // Каждая следующая граница в 2 раза меньше
            }
            return HP.healthStages.Length - 1;
        }
        private void OnComponentInit(HPDisplayComponent component, ComponentInitEvent args)
        {
            HP = component;
        }
        private void OnComponentInit(CharMenuComponent component, ComponentInitEvent args)
        {
            CM = component;
            CM.gameObject.SetActive(false);
        }
        private void OnComponentInit(StatDisplay component, ComponentInitEvent args)
        {
            statDisplays.Add(component);
            if(PlayerSystem._player != null)
                DataRefresh(component);
        }
        private void OnComponentInit(StatusDisplayerComponent component, ComponentInitEvent args)
        {
            statusDisplayers.Add(component);
        }
        private void OnDataInit(PlayerComponent component, ComponentInitEvent args)
        {
            foreach (var item in statDisplays)
            {
                DataRefresh(item, component);
            }
        }
        private void DataRefresh(StatDisplay component)
        {
            if (PlayerSystem._player != null)
                DataRefresh(component, PlayerSystem._player);
        }
        private void DataRefresh(StatDisplay component, PlayerComponent Target)
        {
            switch (component.what)
            {
                case Display.Resistance: component.text.text = "Сопротивление:\n" + Target.Resistance.DictDisplay(); break;
                case Display.Hitpoints: component.text.text = "Повреждения:\n" + Target.Damage.GetTotal(); break;
                case Display.Amplification: component.text.text = "Усиления:\n" + Target.Amplification.DictDisplay(); break;
                case Display.Exp: component.text.text = "Опыт: " + Target.experience + " из " + Target.nextlvlexp; break;
                case Display.Level: component.text.text = "Уровень: " + Target.level; break;
            }
        }
        private void Refresh(StatDisplay component, SimpleComponentEvent args)
        {
            foreach (var item in statDisplays)
            {
                DataRefresh(item);
            }
        }
        private void RefreshStatusDisplay(StatusDisplay item)
        {
            item.round.fillAmount = item.display.TimeProgress();
            item.text.text = item.display.strTimeProgress();
        }

        public override void TickUpdate()
        {
            base.TickUpdate();
            foreach(var list in statusDisplayers)
            {
                List<StatusDisplay> toRemove = new List<StatusDisplay>();
                foreach (var item in list.StatusDisplays)
                {
                    RefreshStatusDisplay(item);
                    if (item.round.fillAmount <= 0 || item.display == null)
                    {
                        toRemove.Add(item);
                    }
                }
                foreach (var item in toRemove)
                {
                    list.StatusDisplays.Remove(item);
                    GameObject.Destroy(item.gameObject);
                }
            }
        }

        private void NewStatus(PlayerComponent component, DisplayStatusEvent args)
        {
            if (args.EntityStatus.icon == null) return;
            foreach (var item in statusDisplayers)
            {
                var temp = GameObject.Instantiate(GameManager.instance.Prefabs.StatusDisplay, item.transform).GetComponent<StatusDisplay>();
                temp.display = args.EntityStatus;
                temp.icon.sprite = temp.display.icon;
                RefreshStatusDisplay(temp);
                item.StatusDisplays.Add(temp);
            }
        }
    }
}
