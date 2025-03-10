using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Core.Roleplay
{
    /// <summary>
    ///     When give damage, or remove, or hold HP we have this
    /// </summary>
    [Serializable]
    public class DamageSpecifier
    {
        public Dictionary<Damage, float> DamageDict {  get; private set; }
        public DamageSpecifier(Dictionary<Damage, float> damage)
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
            return GetSpecific((Damage)(object)type);
        }
        public float GetSpecific(Damage Type)
        {
            if (DamageDict.TryGetValue(Type, out var value))
                return value;
            else
                return 0f;
        }
        public void Add<T>(T type, float count) where T : Enum
        {
            Add((Damage)(object)type, count);
        }
        public void Add(DamageSpecifier Data)
        {
            foreach (var pair in Data.DamageDict)
            {
                Add(pair.Key, pair.Value);
            }
        }
        public void Add(Damage Type, float Count)
        {
            if (DamageDict.TryGetValue(Type, out var value))
                DamageDict[Type] = value + Count;
            else
                DamageDict.Add(Type, Count);
        }
        
        public string Display()
        {
            string data = "Total Damage: " + GetTotal() + "\n";
            foreach (var value in DamageDict)
            {
                data += value.Key + ": " + value.Value + "\n";
            }
            return data;
        }
    }

}

