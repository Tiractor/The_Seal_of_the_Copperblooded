using UnityEngine;
using Unity.Netcode;

public class SimpleNetworkHUD : MonoBehaviour
{
    // ������� ������� ������ ��� ������ (��� �������� ����� ����������������)
    public float baseButtonWidth = 200f;
    public float baseButtonHeight = 40f;

    // ��������� � ������ (��������� ��� ����� ������ ���������)
    public float widthPercentage = 0.2f;
    public float heightPercentage = 0.05f;

    // ������� ������ ������
    public int baseFontSize = 20;

    // GUIStyle ��� ������������ ������ �� �������
    private GUIStyle buttonStyle;

    private void OnGUI()
    {
        // ������������ ������� ������ � ������ � ����������� �� ���������� ������
        float buttonWidth = Screen.width * widthPercentage;
        float buttonHeight = Screen.height * heightPercentage;
        float spacing = buttonHeight * 0.2f; // ������������ ����� ��������
        if (buttonStyle == null)
        {
            buttonStyle = new GUIStyle(GUI.skin.button);
        }
        // ������������ �������������� ������ ������
        buttonStyle.fontSize = Mathf.RoundToInt(baseFontSize * (Screen.width / 1920f)); // 1920 - ������� ���������� ������

        GUILayout.BeginArea(new Rect(10, 10, buttonWidth + 20, Screen.height)); // ������� ������� ��� ������

        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            // ������ ��� ������� �����
            if (GUILayout.Button("Start Host", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.StartHost();
            }

            GUILayout.Space(spacing); // ��������� ������������ ����� ��������

            // ������ ��� ������� �������
            if (GUILayout.Button("Start Server", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.StartServer();
            }

            GUILayout.Space(spacing); // ��������� ������������ ����� ��������

            // ������ ��� ������� �������
            if (GUILayout.Button("Start Client", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.StartClient();
            }
        }
        else
        {
            // ������ ��� ��������� ������� ��� �������
            if (GUILayout.Button("Stop", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.Shutdown();
            }
        }

        GUILayout.EndArea();
    }
}
