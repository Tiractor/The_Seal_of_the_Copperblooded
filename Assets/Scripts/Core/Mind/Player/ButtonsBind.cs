using UnityEngine;
using System.Collections.Generic;
using Core.Events;
using System.Linq;

namespace Core.Mind.Player
{
    public class ButtonsBind : EntitySystem
    {
        public static Dictionary<KeyCode, ComponentEvent> Binds { get; private set; } = new Dictionary<KeyCode, ComponentEvent>();
        public override void Initialize()
        {
            //Subscribe<PlayerComponent, ButtonPressEvent>(OnButtonPress);
            InitBinds();
        }
        private void InitBinds()
        {
            if (!Binds.Values.Any(e => e is PrimaryAttackEvent)) Binds.Add(KeyCode.Mouse0, new PrimaryAttackEvent());
            if (!Binds.Values.Any(e => e is SecondaryAttackEvent)) Binds.Add(KeyCode.Mouse1, new SecondaryAttackEvent());
            if (!Binds.Values.Any(e => e is TertiaryAttackEvent)) Binds.Add(KeyCode.Mouse2, new TertiaryAttackEvent());
        }
        /*void OnButtonPress(PlayerComponent playerComponent, ButtonPressEvent args)
        {
            Logger.Tech("0-1");
            if (Binds.TryGetValue(args.Button, out EntityEvent bind))
            {
                Logger.Tech("0-2");
                TriggerEvent(playerComponent, bind);
            }
        }*/
      
    }
}
