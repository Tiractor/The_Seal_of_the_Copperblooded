using Core.Events;
using UnityEngine;

namespace Core.Roleplay
{
    /// <summary>
    ///     When Entity Attack other Entity
    /// </summary>
    public class AttackEvent : ComponentEvent 
    {
        public EntityComponent Target;
        public EntityComponent Inititor;
        public AttackEvent(EntityComponent target)
        {
            this.Target = target;
        }
        public AttackEvent(EntityComponent inititor, EntityComponent target)
        {
            this.Target = target;
            this.Inititor = inititor;
        }
        public AttackEvent(GameObject initiator, EntityComponent target)
        {
            Initiator = initiator;
            this.Target = target;
        }
    }

}