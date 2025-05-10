using Core.Events;
using Core.Mind.Player;
using System.Collections.Generic;

namespace Core.UI
{
    public class StatsDisplaySystem : ComponentSystem
    {
        public static HashSet<StatDisplay> statDisplays = new HashSet<StatDisplay>();
        public override void Initialize()
        {
            Subscribe<StatDisplay, ComponentInitEvent>(OnComponentInit);
            Subscribe<PlayerComponent, ComponentInitEvent>(OnDataInit);
            Subscribe<StatDisplay, SimpleComponentEvent>(Refresh);
            Subscribe<UpdateDisplayEvent>(TargetRefresh);
        }
        private void TargetRefresh(UpdateDisplayEvent args)
        {
            Logger.Warn(0);
            foreach (var item in statDisplays)
            {
                if(item.what == args.What)
                    DataRefresh(item);
            }
        }
        private void OnComponentInit(StatDisplay component, ComponentInitEvent args)
        {
            Logger.Info(1);
            statDisplays.Add(component);
            if(PlayerSystem._player != null)
                DataRefresh(component);
        }
        private void OnDataInit(PlayerComponent component, ComponentInitEvent args)
        {
            Logger.Info(0);
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
    }
}
