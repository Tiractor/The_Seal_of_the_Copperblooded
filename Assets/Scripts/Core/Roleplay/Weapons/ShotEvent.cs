using Core.Events;
using UnityEngine;

namespace Core.Roleplay.Attack
{
    /// <summary>
    ///     When Entity Attack other Entity
    /// </summary>
    public class ShotEvent : ComponentEvent 
    {
        public EntityComponent Target;

        public ShotEvent(EntityComponent target)
        {
            this.Target = target;
        }
        public ShotEvent(GameObject initiator, EntityComponent target)
        {
            Initiator = initiator;
            this.Target = target;
        }
    }

}