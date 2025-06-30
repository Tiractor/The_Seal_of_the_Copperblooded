using System;
using Core.Roleplay.Inventory;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public class SummonObjectEffect : EntityEffect
    {
        
       public GameObject target;
        public override void Effect<T>(T component)
        {
            GameObject.Instantiate(target, component.transform.position, component.transform.rotation);
        }
    }
}