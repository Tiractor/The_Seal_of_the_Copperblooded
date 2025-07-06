using System;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public class RandomAnimationTriggerEffect : EntityEffect
    {
        public Animator controller;
        public string Var1;
        public string Var2;
        public override void Effect<T>(T component)
        {
            var res = UnityEngine.Random.Range(0, 2) == 0 ? Var1 : Var2;
            controller.Play(res);
        }
    }
}