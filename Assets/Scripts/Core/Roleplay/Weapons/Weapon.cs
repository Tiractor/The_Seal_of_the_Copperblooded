using Core.EntityEffects;
using System;
using System.Collections.Generic;

namespace Core.Roleplay.Weapons
{
    [Serializable]
    public abstract class Weapon
    {
       public List<EntityEffect> WeaponEffects;
    }
}