using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryBtn : MonoBehaviour
{
    public float timeLeft = 4f;
    private Image _myImage;
    private Button _btn;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _myImage = GetComponent<Image>();
        _btn = GetComponent<Button>();
    }
    public void Update()
    {
        Timer();
        if(timeLeft <= 0)
        {
            _myImage.enabled = true;
            _btn.enabled = true;
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void Win()
    {
        SceneManager.LoadScene("Start_Dialogue");
    }
    void Timer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
    }
}
