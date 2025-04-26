using Core.Events;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{
    public class EntityUID : EventComponent
    {
        [SerializeField] private int uID = 0;
        //public Dictionary<Type, EventComponent> Components;
        public int UID { get { return uID; } private set { } }
        public void SetUID(int newUID)
        {
            uID = newUID;
        }

    }
}