using System;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Roleplay.Inventory
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "InventoryComponent/Item")]
    [Serializable]
    public class Item : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public bool stackable = false;
        public int maxStack = 1;
        public List<ItemTags> Tags;
        public bool canBeEquip = false; 

        [TextArea]
        public string description;
    }
}