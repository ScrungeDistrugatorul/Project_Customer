using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryBtn : MonoBehaviour
{
    public float timeLeft = 4f;
    private Image _myImage;
    private Button _btn;
    public GameObject gameText;
    private Text _text;
    public GameObject importantText;
    public GameObject fadeScreen;

    public AudioSource audioSource;
    public AudioClip boom;
    private const float Volume = 0.1f;

    public Animator cutscene;
    private static readonly int Fade = Animator.StringToHash("Fade");
    

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _myImage = GetComponent<Image>();
        _btn = GetComponent<Button>();
        _text = gameText.GetComponent<Text>();
        audioSource.PlayOneShot(boom,Volume);
        cutscene.SetBool(Fade, false);
    }
    public void Update()
    {
        Timer();
        if (timeLeft <= 3)
        {
            importantText.SetActive(true);
        }

        if (timeLeft <= 2)
        {
            fadeScreen.SetActive(false);
        }
        if(timeLeft <= 0)
        {
            _myImage.enabled = true;
            _btn.enabled = true;
            _text.enabled = true;
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
