using Core.Events;
using UnityEngine;
namespace Core.Mind.Player
{
    public class CameraController : EventComponent
    {
        [SerializeField]
        Transform character;
        public float sensitivity = 2;
        public float smoothing = 1.5f;
        public Camera Camera;
        Vector2 velocity;
        Vector2 frameVelocity;


        void Reset()
        {
            // Get the character from the FirstPersonMovement in parents.
            character = GetComponentInParent<PlayerController>().transform;
            Camera = GetComponent<Camera>();
        }


        void Update()
        {
            if (Cursor.lockState == CursorLockMode.None) return;
            // Get smooth velocity.
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90);

            // Rotate camera up-down and controller left-right from velocity.
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }
    }
}