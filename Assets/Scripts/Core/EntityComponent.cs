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
    public class EntityComponent : EventComponent
    {
        [SerializeField] public DamageSpecifier Damage;
        [SerializeField] public int DamageThreshold = 100; 
        [SerializeField] public HashSet<EntityStatus> Statuses = new();
    }
}