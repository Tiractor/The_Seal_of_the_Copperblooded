using System.Collections.Generic;

namespace core.roleplay
{
    /// <summary>
    ///     When give damage, or remove, or hold HP we have this
    /// </summary>
    public class DamageSpecifier
    {
        public Dictionary<string, float> DamageDict;
        public DamageSpecifier(Dictionary<string, float> damage)
        {
            DamageDict = damage;
        }

        public float GetTotal()
        {
            var total = 0f;
            foreach (var value in DamageDict.Values)
            {
                total += value;
            }
            return total;
        }

    }

}

