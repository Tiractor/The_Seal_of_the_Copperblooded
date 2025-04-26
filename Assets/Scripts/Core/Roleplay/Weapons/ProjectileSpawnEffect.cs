using System;
using Core.EntityEffects;
using UnityEngine;

namespace Core.Roleplay.Attack
{
    [Serializable]
    public class ProjectileSpawnEffect : EntityEffect
    {
        
        public GameObject _projectile;
        public override void Effect<T>(T component)
        {
            GameObject.Instantiate(_projectile, component.transform);
        }
    }
}