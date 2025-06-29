using Core.Events;
using UnityEngine;

namespace Core.Mind.NPC
{
    public class DamageFlashComponent : EventComponent
    {
        public Renderer targetRenderer;
        public Color flashColor = Color.red;
        public float flashDuration = 0.15f;

        [HideInInspector] public Color originalColor;
        [HideInInspector] public float timer = 0f;
        [HideInInspector] public bool isFlashing = false;
    }
}
