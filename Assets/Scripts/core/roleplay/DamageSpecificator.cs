using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Roleplay
{
    /// <summary>
    ///     When give damage, or remove, or hold HP we have this
    /// </summary>
    [Serializable]
    public class DamageSpecifier
    {
        public Dictionary<string, float> DamageDict;
        public DamageSpecifier(Dictionary<string, float> damage)
        {
            DamageDict = damage;
        }
        public DamageSpecifier()
        {
            DamageDict = new();
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

