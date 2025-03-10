using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(NetworkObject))]
public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        if (!IsOwner) return;
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        var moveDelta = new Vector3(moveX, 0, moveZ);
        if (moveDelta.magnitude > 0.02f * Time.deltaTime)
        {
            transform.Translate(moveDelta);
            SendMovementToServerRpc(moveDelta);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void SendMovementToServerRpc(Vector3 moveDelta)
    {
        // Обновляем позицию на сервере

        transform.Translate(moveDelta);

        // Отправляем позицию всем клиентам
        UpdatePositionClientRpc(transform.position);
    }
    [ClientRpc]
    void UpdatePositionClientRpc(Vector3 newPosition)
    {
        if (!IsOwner) // Только другие клиенты должны получать обновления
        {
            transform.position = newPosition;
        }
    }
}
