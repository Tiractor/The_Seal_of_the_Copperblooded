using Core.Events;
using UnityEngine;
namespace Core
{
    public class EntityUID : EventComponent
    {
        [SerializeField] private int uID = 0;
        public int UID { get { return uID; } private set { } }
        public void SetUID(int newUID)
        {
            uID = newUID;
        }
    }
}