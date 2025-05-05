using Core.Events;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Core.Roleplay.Inventory
{
    public class InventoryComponent : EventComponent
    {
        public int UID = -1;
        public List<InventorySlot> slots = new();
        [ContextMenu("Сканировать слоты в дочерних объектах")]
        public void CollectSlots()
        {
            slots.Clear();
            InventorySlot[] foundSlots = GetComponentsInChildren<InventorySlot>(true);
            foreach (var slot in foundSlots)
            {
                if (!slots.Contains(slot))
                    slots.Add(slot);
            }
#if UNITY_EDITOR
            // Помечает объект как "изменённый", чтобы Unity не потеряла изменения при сериализации
            EditorUtility.SetDirty(this);
#endif
            Debug.Log($"Найдено {slots.Count} слотов.");
        }
    }
}
