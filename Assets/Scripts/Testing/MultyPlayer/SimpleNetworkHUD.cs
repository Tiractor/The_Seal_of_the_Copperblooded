using UnityEngine;
using Unity.Netcode;

public class SimpleNetworkHUD : MonoBehaviour
{
    // Задайте базовый размер для кнопок (это значение будет масштабироваться)
    public float baseButtonWidth = 200f;
    public float baseButtonHeight = 40f;

    // Отношение к экрану (изменяйте для более точной настройки)
    public float widthPercentage = 0.2f;
    public float heightPercentage = 0.05f;

    // Базовый размер шрифта
    public int baseFontSize = 20;

    // GUIStyle для кастомизации текста на кнопках
    private GUIStyle buttonStyle;

    private void OnGUI()
    {
        // Рассчитываем размеры кнопок и текста в зависимости от разрешения экрана
        float buttonWidth = Screen.width * widthPercentage;
        float buttonHeight = Screen.height * heightPercentage;
        float spacing = buttonHeight * 0.2f; // Пространство между кнопками
        if (buttonStyle == null)
        {
            buttonStyle = new GUIStyle(GUI.skin.button);
        }
        // Рассчитываем масштабируемый размер шрифта
        buttonStyle.fontSize = Mathf.RoundToInt(baseFontSize * (Screen.width / 1920f)); // 1920 - базовое разрешение экрана

        GUILayout.BeginArea(new Rect(10, 10, buttonWidth + 20, Screen.height)); // Создаем область для кнопок

        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            // Кнопка для запуска хоста
            if (GUILayout.Button("Start Host", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.StartHost();
            }

            GUILayout.Space(spacing); // Добавляем пространство между кнопками

            // Кнопка для запуска сервера
            if (GUILayout.Button("Start Server", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.StartServer();
            }

            GUILayout.Space(spacing); // Добавляем пространство между кнопками

            // Кнопка для запуска клиента
            if (GUILayout.Button("Start Client", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.StartClient();
            }
        }
        else
        {
            // Кнопка для остановки сервера или клиента
            if (GUILayout.Button("Stop", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.Shutdown();
            }
        }

        GUILayout.EndArea();
    }
}
