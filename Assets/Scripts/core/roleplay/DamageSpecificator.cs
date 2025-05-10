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
        public bool IsPercent;
        public DamageSpecifier(Dictionary<DamageType, float> damage)
        {
            DamageDict = damage;
        }
        public DamageSpecifier()
        {
            DamageDict = new();
        }
        public DamageSpecifier(bool isPercent)
        {
            DamageDict = new();
            IsPercent = isPercent;
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
        public string DictDisplay()
        {
            string data = "";
            foreach (var value in DamageDict)
            {
                if (value.Value != 0)
                {
                    var pe = IsPercent ? (value.Value * 100) + "%" : value.Value.ToString();
                    data += DamageTypeExtensions.ToLocalizedString(value.Key) + ": " + pe + "\n";
                }
            }
            return data;
        }
        public static DamageSpecifier operator *(DamageSpecifier first, DamageSpecifier second)
        {
            var result = new DamageSpecifier(first.IsPercent);
            foreach (var pair in first.DamageDict)
            {
                if (second.DamageDict.TryGetValue(pair.Key, out var secondValue))
                {
                    result.Add(pair.Key, pair.Value * secondValue);
                } 
                else
                    result.Add(pair.Key, pair.Value);
            }
            return result;
        }
        public static DamageSpecifier operator *(DamageSpecifier first, int second)
        {
            var result = new DamageSpecifier(first.IsPercent);
            foreach (var pair in first.DamageDict)
            {
                result.Add(pair.Key, pair.Value * second);
            }
            return result;
        }
        public static DamageSpecifier operator +(DamageSpecifier first, int second)
        {
            var result = new DamageSpecifier(first.IsPercent);
            foreach (var pair in first.DamageDict)
            {
                result.Add(pair.Key, pair.Value + second);
            }
            return result;
        }
        public static DamageSpecifier operator +(DamageSpecifier first, DamageSpecifier second)
        {
            var result = new DamageSpecifier(first.IsPercent);

            var allKeys = new HashSet<DamageType>(first.DamageDict.Keys);
            allKeys.UnionWith(second.DamageDict.Keys);

            foreach (var key in allKeys)
            {
                float value1 = first.DamageDict.TryGetValue(key, out var v1) ? v1 : 0;
                float value2 = second.DamageDict.TryGetValue(key, out var v2) ? v2 : 0;

                result.Add(key, value1 + value2);
            }

            return result;
        }
    }

}

