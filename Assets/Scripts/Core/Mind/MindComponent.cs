using Core.Roleplay.Attack;
using Core.Roleplay.Progress;
using UnityEngine;

namespace Core.Mind
{
    public abstract class MindComponent : LevelComponent
    {
        [SerializeReference] public WeaponComponent PrimaryAttack;
        [SerializeReference] public WeaponComponent SecondaryAttack;
        [SerializeReference] public WeaponComponent TertiaryAttack;
    }
}
