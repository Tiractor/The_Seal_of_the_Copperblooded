namespace Core.Roleplay
{
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
    public enum Damage 
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
