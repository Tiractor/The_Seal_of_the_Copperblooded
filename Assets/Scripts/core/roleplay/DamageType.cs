using System;

namespace Core.Roleplay
{
    [Serializable]
    public struct Damage 
    {
        public Damage(DamageType type, float count)
        {
            Type = type;
            Count = count;
        }
        public DamageType Type;
        public float Count;
    }
    public enum DamageTypes
    {
        BurnDamage = 0,
        MagicDamage,
        PhysicDamage,
        BiologicDamage
    }

    public enum BurnDamage
    {
        Heat,
        Shock,
        Cold,
        Caustic
    }

    public enum MagicDamage
    {
        Holy = 4,
        Taint,
        Desiccation
    }

    public enum PhysicDamage
    {
        Blunt = 7,
        Slash,
        Piercing
    }
    public enum BiologicDamage
    {
        Asphyxiation = 10,
        Bloodloss,
        Cellular,
        Poison
    }
    public enum DamageType 
    {
        Heat,
        Shock,
        Cold,
        Caustic,
        Holy,
        Taint,
        Desiccation,
        Blunt,
        Slash,
        Piercing,
        Asphyxiation,
        Bloodloss,
        Cellular,
        Poison
    }

}
