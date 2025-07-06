using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Core.Mind.Player
{
    public class ButtonsBind : ComponentSystem
    {
        public static Dictionary<KeyCode, ButtonEvent> Binds { get; private set; } = new Dictionary<KeyCode, ButtonEvent>();
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
            if (!Binds.Values.Any(e => e is InventorySwitchEvent)) Binds.Add(KeyCode.Tab, new InventorySwitchEvent());
            if (!Binds.Values.Any(e => e is CodexSwitchEvent)) Binds.Add(KeyCode.J, new CodexSwitchEvent());
            if (!Binds.Values.Any(e => e is InteractEvent)) Binds.Add(KeyCode.E, new InteractEvent());
        }
      
    }
}
