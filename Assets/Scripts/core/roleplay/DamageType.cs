namespace Core.Roleplay
{
    public enum DamageTypes
    {
        BurnDamage,
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
        Holy,
        Taint,
        Desiccation
    }

    public enum PhysicDamage
    {
        Blunt,
        Slash,
        Piercing
    }

    public enum BiologicDamage
    {
        Asphyxiation,
        Bloodloss,
        Cellular,
        Poison
    }
}
