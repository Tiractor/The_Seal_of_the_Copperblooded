using Core.EntityEffects;
using Core.Events;
using UnityEngine;

namespace Core.Interactable
{
    [RequireComponent(typeof(Collider))]
    public class InteractableComponent : EventComponent
    {
        public string prompt = "Нажмите E для взаимодействия";
        [HideInInspector] public Renderer highlightRenderer;
        public Color highlightColor = Color.yellow;

        [HideInInspector] public Color originalColor;
        [SerializeReference] public EntityEffect[] _interactEffects = new EntityEffect[0];
    }
}
