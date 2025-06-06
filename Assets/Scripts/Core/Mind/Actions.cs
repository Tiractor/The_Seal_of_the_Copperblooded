using Core.Events;

namespace Core.Mind.Player
{
    public class ButtonEvent : ComponentEvent { public bool inGameOnly = true; }

    public class PrimaryAttackEvent : ButtonEvent { }
    public class SecondaryAttackEvent : ButtonEvent { }
    public class TertiaryAttackEvent : ButtonEvent { }
    public class InventorySwitchEvent : ButtonEvent { public InventorySwitchEvent() { inGameOnly = false; } }
    public class InteractEvent : ButtonEvent { }

}