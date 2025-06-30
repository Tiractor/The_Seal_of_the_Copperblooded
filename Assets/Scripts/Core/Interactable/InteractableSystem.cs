using Core.Events;
using Core.Mind.Player;
using UnityEngine;

namespace Core.Interactable
{
    public class InteractableSystem : ComponentSystem
    {
        public Camera mainCamera;
        public float interactDistance = 3f;
        public InteractUI interactUI;

        private InteractableComponent current;

        public override void Initialize()
        {
            Subscribe<InteractableComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<InteractUI, ComponentInitEvent>(OnComponentInit);
            Subscribe<CameraController, ComponentInitEvent>(OnComponentInit);
            Subscribe<PlayerComponent, InteractEvent>(OnInteract);
        }
        private void OnComponentInit(InteractableComponent component, ComponentInitEvent args)
        {
            component.highlightRenderer = component.GetComponent<Renderer>();
        }
        private void OnComponentInit(InteractUI component, ComponentInitEvent args)
        {
            interactUI = component;
            interactUI?.Hide();
        }
        private void OnComponentInit(CameraController component, ComponentInitEvent args)
        {
            mainCamera = component.Camera;
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void OnInteract(PlayerComponent component, InteractEvent args)
        {
            Debug.Log(current);
            foreach (var eff in current._interactEffects)
            {
                eff.Effect(component);
            }
            interactUI?.Hide();
        }
        public override void TickUpdate()
        {
            if (mainCamera == null) return;
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                var interactable = hit.collider.GetComponentInParent<InteractableComponent>();
                if (interactable != null)
                {
                    if (current != interactable)
                    {
                        ResetHighlight();

                        current = interactable;
                        ApplyHighlight(current);
                        interactUI?.Show(current.prompt);
                    }

                    return;
                }
            }

            // Если не навели ни на что
            if (current != null)
            {
                ResetHighlight();
                interactUI?.Hide();
                current = null;
            }
        }

        private void ApplyHighlight(InteractableComponent component)
        {
            if (component.highlightRenderer != null)
            {
                var mat = component.highlightRenderer.material;
                component.originalColor = mat.color;
                mat.color = component.highlightColor;
            }
        }

        private void ResetHighlight()
        {
            if (current?.highlightRenderer != null)
            {
                current.highlightRenderer.material.color = current.originalColor;
            }
        }
    }
}
