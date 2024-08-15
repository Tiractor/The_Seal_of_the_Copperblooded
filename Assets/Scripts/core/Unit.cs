using core.events;
using core.roleplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace core 
{
    public sealed class Unit : Entity
    {
        // Start is called before the first frame update
        void Awake()
        {
            Subscribe<DamageEvent>(this, Test);
        }

        // Update is called once per frame
        void Start()
        {
            TriggerEvent(this, new DamageEvent());
        }
        static void Test(EventComponent component, DamageEvent args)
        {
            Debug.Log(component.gameObject.name + " " + args.Initiator.name);
        }

    }
}