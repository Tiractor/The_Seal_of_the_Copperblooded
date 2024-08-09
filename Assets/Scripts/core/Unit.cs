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
            Subscribe<DamageEvent>(Test);
        }

        // Update is called once per frame
        void Start()
        {
            TriggerEvent(new DamageEvent());
        }
        void Test(DamageEvent args)
        {
            Debug.Log(args.Initiator.name);
        }

    }
}