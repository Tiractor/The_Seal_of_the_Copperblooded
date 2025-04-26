using Core.Events;
using UnityEngine;

namespace Core.Roleplay
{
    /// <summary>
    ///     When Entity Attack other Entity
    /// </summary>
    public class AttackEvent : EntityEvent 
    {
        public EntityComponent Target;
        public AttackEvent(EntityComponent target)
        {
            this.Target = target;
        }
        public AttackEvent(GameObject initiator, EntityComponent target)
        {
            Initiator = initiator;
            this.Target = target;
        }
    }

}