using UnityEngine;
using Unity.Netcode;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    private void Awake()
    {
        // Singleton ��� ������� � �����-���������
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // �������� �� ������� ����������� � ���������� ��������
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

    // ���������� ����������� ������
    private void OnClientConnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} connected.");
        LobbyUI.Instance.ConnectedClient(clientId); // ���������� ������ ������� � UI
        LobbyUI.Instance.SendPlayerListServerRpc();
    }

    // ���������� ���������� ������
    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} disconnected.");
        LobbyUI.Instance.DisconnectClient(clientId); // ���������� ������ ������� � UI
        LobbyUI.Instance.SendPlayerListServerRpc();
    }
}
