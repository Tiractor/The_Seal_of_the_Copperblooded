using System;
using System.Collections.Generic;

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
    public static class DamageTypeExtensions
    {
        private static readonly Dictionary<DamageType, string> _displayNames = new()
    {
        { DamageType.Heat, "Жар" },
        { DamageType.Shock, "Электричество" },
        { DamageType.Cold, "Холод" },
        { DamageType.Caustic, "Кислота" },
        { DamageType.Holy, "Святой" },
        { DamageType.Taint, "Порча" },
        { DamageType.Desiccation, "Иссушение" },
        { DamageType.Blunt, "Дробящий" },
        { DamageType.Slash, "Режущий" },
        { DamageType.Piercing, "Колющий" },
        { DamageType.Asphyxiation, "Удушье" },
        { DamageType.Bloodloss, "Кровопотеря" },
        { DamageType.Cellular, "Клеточный" },
        { DamageType.Poison, "Яд" }
    };

        public static string ToLocalizedString(this DamageType damageType)
        {
            return _displayNames.TryGetValue(damageType, out var name) ? name : damageType.ToString();
        }
    }
}
