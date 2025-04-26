using Core.EntityEffects;
using UnityEngine;

namespace Core.Collide 
{ 
    public class ContactEffector : CollideableComponent
    {
        [SerializeReference] public EntityEffect[] _effects = new EntityEffect[0];
    }
}