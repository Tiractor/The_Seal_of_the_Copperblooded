using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;

[RequireComponent(typeof(NetworkObject))]
public class LobbyUI : NetworkBehaviour
{
    public static LobbyUI Instance;

    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Button startButton;

    public GameObject TemplateClient;

    [SerializeField] private RectTransform Clients;
    [SerializedDictionary("ClientID", "DisplayObject")]
    public SerializedDictionary<ulong,ClientConnectedHandler> Players;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        hostButton.onClick.AddListener(CreateHost);
        clientButton.onClick.AddListener(JoinLobby);
        startButton.onClick.AddListener(StartGame);

        // Стартовая кнопка активна только для хоста
        startButton.gameObject.SetActive(false);
    }

    private void CreateHost()
    {
        NetworkManager.Singleton.StartHost();
        startButton.gameObject.SetActive(true);  // Активируем кнопку старта для хоста
        SendPlayerListServerRpc();
    }

    private void JoinLobby()
    {
        NetworkManager.Singleton.StartClient();
    }

    private void StartGame()
    {
        // Тут можно запустить сцену с игрой
        NetworkManager.Singleton.SceneManager.LoadScene("GameScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void DisconnectClient(ulong ID)
    {
        Players.TryGetValue(ID, out var Object);
        Destroy(Object.gameObject);
        Players.Remove(ID);
    }
    public void ConnectedClient(ulong ID)
    {
        Instantiate(TemplateClient, Clients).TryGetComponent<ClientConnectedHandler>(out var obj);
        Players[ID] = obj;
        obj.Text.text = ID.ToString();
    }
    [ServerRpc(RequireOwnership = false)]
    public void SendPlayerListServerRpc()
    {
        if (IsServer)
        {
            // Получаем список клиентов на сервере
            List<ulong> clientIds = new List<ulong>();
            foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
            {
                clientIds.Add(client.ClientId);
            }

            // Отправляем этот список всем клиентам
            UpdatePlayerListClientRpc(clientIds.ToArray());
        }
    }
    [ClientRpc]
    public void UpdatePlayerListClientRpc(ulong[] clientList)
    {
        foreach (var client in clientList)
        {
            if (Players.ContainsKey(client)) continue;
            ConnectedClient(client);
        }
    }
}
