using System.Globalization;
using UnityEditor.ShaderGraph;
using UnityEngine;

namespace Core.Mind.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void Update()
        {
            float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            var moveDelta = new Vector3(moveX, 0, moveZ);
            if (moveDelta.magnitude > 0.02f * Time.deltaTime)
            {
                transform.Translate(moveDelta);
            }

        }
    }
}