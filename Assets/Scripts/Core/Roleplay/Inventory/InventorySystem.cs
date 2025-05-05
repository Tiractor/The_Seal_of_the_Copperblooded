using Core.Events;
using System.Collections.Generic;

namespace Core.Roleplay.Inventory
{
    public class InventorySystem : ComponentSystem
    {
        Dictionary<int, HashSet<InventoryComponent>> Inventories = new Dictionary<int, HashSet<InventoryComponent>>();
        public override void Initialize()
        {
            Subscribe<InventoryComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<InventoryComponent, SimpleComponentEvent>(OnUpdate);
        }
        private void OnComponentInit(InventoryComponent component, ComponentInitEvent args)
        {
            if (component.UID == -1) return;
            var list = new HashSet<InventoryComponent>();
            if (Inventories.TryGetValue(component.UID, out list))
            {
                Inventories.Remove(component.UID);
            }
            list.Add(component);
            Inventories.Add(component.UID, list);
        }
        private void OnUpdate(InventoryComponent component, SimpleComponentEvent args)
        {
            if (component.UID == -1) return;
            Inventories.TryGetValue(component.UID, out var list);
            foreach (var item in list)
            {
                if (item == component) continue;
                Replace(item,component);
                Refresh(item);
            }
        }
        private void Refresh(InventoryComponent component)
        {
            foreach (var item in component.slots)
            {
                item.RefreshData();
            }
        }
        private void Replace(InventoryComponent component, InventoryComponent New)
        {
            for(int i = 0; i < component.slots.Count; ++i)
            {
                component.slots[i].data.amount = New.slots[i].data.amount;
                component.slots[i].data.item = New.slots[i].data.item;
            }
        }
    }
}
