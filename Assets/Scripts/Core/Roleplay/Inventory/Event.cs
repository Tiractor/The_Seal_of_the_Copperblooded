using Core.Events;
namespace Core.Roleplay.Inventory
{
    public class EquipEvent : ComponentEvent
    {
        public Equipment EquippedItem;
        public bool IsEquipped;
        public EquipEvent(Equipment equippedItem, bool isEquipped)
        {
            EquippedItem = equippedItem;
            IsEquipped = isEquipped;
        }
    }
    public class AddItemEvent : ComponentEvent
    {
        public SlotData item;
        public AddItemEvent(SlotData newItem)
        {
            item = newItem;
        }
    }
}