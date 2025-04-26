using Core.EntityEffects;
using Core.Events;
using UnityEngine;

namespace Core.Roleplay.Attack
{
    [RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Collider))]
    public class ProjectileComponent : EventComponent
    {
        [SerializeReference] public EntityEffect[] _onContactEffects = new EntityEffect[0];
    }
}