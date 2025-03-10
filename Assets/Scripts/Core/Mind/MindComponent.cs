using Core.Roleplay.Weapons;
using UnityEngine;

namespace Core.Mind
{
    public abstract class MindComponent : EntityComponent
    {
        [SerializeReference] public Weapon Weapon;
    }
}
