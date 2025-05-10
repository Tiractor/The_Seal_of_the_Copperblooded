using System;
using UnityEngine;
namespace Core.Roleplay.Inventory
{
    [CreateAssetMenu(fileName = "NewEquipment", menuName = "InventoryComponent/Equipment")]
    [Serializable]
    public class Equipment : Item
    {
        public GameObject prefab;

        public Damage[] _damage;
        public DamageSpecifier damageSpecifier;
        public bool damageIsPercent;
        public void OnValidate()
        {
            var Damage = new DamageSpecifier(damageIsPercent);
            canBeEquip = true;
            Damage.Add(_damage);
            damageSpecifier = Damage;
        }

    }
}