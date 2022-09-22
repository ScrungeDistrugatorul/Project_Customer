using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Start_Dialogue");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
