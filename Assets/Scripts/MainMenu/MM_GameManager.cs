using UnityEngine;
using UnityEngine.SceneManagement;

public class MM_GameManager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Playzone");
    }
}
