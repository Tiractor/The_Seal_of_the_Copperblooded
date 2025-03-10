using Core.Events;
using System.Collections.Generic;

namespace Core
{
    public class UIDSystem : ComponentSystem
    {
        private static int LastUsedID = 1;
        Dictionary<int, EntityUID> Data;
        public override void Initialize()
        {
            Data = new Dictionary<int, EntityUID>();
            Subscribe<EntityUID, ComponentInitEvent>(AddUID);
        }

        public void AddUID(EntityUID uID, ComponentInitEvent args)
        {
            while(Data.TryGetValue(LastUsedID++, out var entity))
            {

            }
            Data.Add(LastUsedID, uID);
            uID.SetUID(LastUsedID);
        }
    }
}
