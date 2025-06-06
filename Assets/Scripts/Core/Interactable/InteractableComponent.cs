using Core.EntityEffects;
using Core.Events;
using UnityEngine;

namespace Core.Interactable
{
    public class InteractableComponent : EventComponent
    {
        public string prompt = "Press E to interact";
        [HideInInspector] public Renderer highlightRenderer;
        public Color highlightColor = Color.yellow;

        [HideInInspector] public Color originalColor;
        [SerializeReference] public EntityEffect[] _interactEffects = new EntityEffect[0];
    }
}
