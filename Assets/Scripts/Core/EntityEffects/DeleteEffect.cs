using System;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public class DeleteEffect : EntityEffect
    {
        
        [SerializeReference] public GameObject target;
        public override void Effect<T>(T component)
        {
            GameObject.Destroy(target);
        }
    }
}