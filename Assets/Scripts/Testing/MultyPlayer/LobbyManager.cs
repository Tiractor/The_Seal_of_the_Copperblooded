using UnityEngine;
using Unity.Netcode;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    private void Awake()
    {
        // Singleton для доступа к лобби-менеджеру
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Подписка на события подключения и отключения клиентов
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
        }
    }

    // Обработчик подключения игрока
    private void OnClientConnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} connected.");
        LobbyUI.Instance.ConnectedClient(clientId); // Обновление списка игроков в UI
        LobbyUI.Instance.SendPlayerListServerRpc();
    }

    // Обработчик отключения игрока
    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} disconnected.");
        LobbyUI.Instance.DisconnectClient(clientId); // Обновление списка игроков в UI
        LobbyUI.Instance.SendPlayerListServerRpc();
    }
}
