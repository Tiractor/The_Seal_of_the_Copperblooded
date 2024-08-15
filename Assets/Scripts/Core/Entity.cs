using core.events;
using core.roleplay;
using System;
using UnityEngine;

namespace core 
{
    /// <summary>
    ///     Base class for interactable objects
    /// </summary>
    public class Entity : EventComponent
    {
        DamageSpecifier damage;
    }
}