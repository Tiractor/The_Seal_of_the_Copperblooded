using core.events;
using core.roleplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace core.roleplay
{
    public class UnitSystem : ComponentSystem
    {
        public override void Initialize()
        {
            Subscribe<UnitComponent, ComponentInit>(OnComponentInit);
        }
        static void OnComponentInit(UnitComponent component, ComponentInit args) 
        {
            Debug.Log(args.Initiator.name);
        }
        // Update is called once per frame
        
        static void Test(EventComponent component, DamageEvent args)
        {
            Debug.Log(component.gameObject.name + " " + args.Initiator.name);
        }
    }
}