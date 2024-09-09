using System.Collections.Generic;
using UnityEngine;

namespace Core.Roleplay 
{
    public sealed class UnitComponent : EntityComponent
    {
        // Start is called before the first frame update
        [SerializeField]
        private Dictionary<string, float> _nameOverrides;
    }
}