using Core.EntityStatuses;
using Core.Events;
using Core.Roleplay;
using System.Collections.Generic;
using UnityEngine;

namespace Core 
{
    /// <summary>
    ///     Base class for interactable objects
    /// </summary>
    [RequireComponent(typeof(EntityUID))]
    public abstract class EntityComponent : EventComponent
    {
        [SerializeField] public DamageSpecifier Damage;
        [SerializeField] public DamageSpecifier Resistance;
        [SerializeField] public DamageSpecifier Amplification;
        [SerializeField] public int DamageThreshold = 100; 
        [SerializeField] public HashSet<EntityStatus> Statuses = new();

        [ContextMenu("Statuses")]
        public void DisplayStatuses()
        {
            foreach (var stat in Statuses)
            {
                Logger.Info(stat.GetType().Name);
            }
        }
        [ContextMenu("Damages")]
        public void DisplayDamage()
        {
            Logger.Info(Damage.Display());
        }
        private void OnValidate()
        {
            Resistance.IsPercent = true;
            Amplification.IsPercent = true;
        }
    }
}