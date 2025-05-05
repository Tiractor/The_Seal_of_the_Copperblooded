using Core.EntityEffects;
using Core.Events;
using UnityEngine;

namespace Core.Roleplay.Attack
{
    public class WeaponComponent : EventComponent
    {
        [SerializeReference] public EntityEffect[] _weaponEffects = new EntityEffect[0];
        public float Range = 2;
    }
}