using System;
using System.Collections.Generic;

namespace Core.Roleplay
{
    /// <summary>
    ///     When give damage, or remove, or hold HP we have this
    /// </summary>
    [Serializable]
    public class DamageSpecifier
    {
        public Dictionary<DamageType, float> DamageDict {  get; private set; }
        public DamageSpecifier(Dictionary<DamageType, float> damage)
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
        public float GetSpecific<T>(T type) where T : Enum
        {
            return GetSpecific((DamageType)(object)type);
        }
        public float GetSpecific(DamageType Type)
        {
            if (DamageDict.TryGetValue(Type, out var value))
                return value;
            else
                return 0f;
        }
        public void Add<T>(T type, float count) where T : Enum
        {
            Add((DamageType)(object)type, count);
        }
        public void Add(Damage[] Data)
        {
            foreach (var pair in Data)
            {
                Add(pair.Type, pair.Count);
            }
        }
        public void Add(DamageSpecifier Data)
        {
            foreach (var pair in Data.DamageDict)
            {
                Add(pair.Key, pair.Value);
            }
        }
        public void Add(DamageType Type, float Count)
        {
            if (DamageDict.TryGetValue(Type, out var value))
                DamageDict[Type] = value + Count;
            else
                DamageDict.Add(Type, Count);
        }
        
        public string Display()
        {
            string data = "Total DamageType: " + GetTotal() + "\n";
            foreach (var value in DamageDict)
            {
                data += value.Key + ": " + value.Value + "\n";
            }
            return data;
        }
    }

}

