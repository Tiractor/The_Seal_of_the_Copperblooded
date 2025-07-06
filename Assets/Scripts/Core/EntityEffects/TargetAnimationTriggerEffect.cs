using System;
using UnityEngine;

namespace Core.EntityEffects
{
    [Serializable]
    public class TargetAnimationTriggerEffect : EntityEffect
    {
        public Animator controller;
        public string animationname;
        public override void Effect<T>(T component)
        {
            controller.Play(animationname);
        }
    }
}