using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    public Animator cutscene;

    private bool _playerName;
    public bool loadScene;

    public GameObject pistol;
    public Font mainFont;

    private Queue<string> _storyText;

    public bool canEquipPistol;
    private bool _timer;
    private float timeLeft = 1f;
    
    private static readonly int IsOpened = Animator.StringToHash("IsOpened");
    private static readonly int IsCutscene = Animator.StringToHash("IsCutscene");

    // Start is called before the first frame update
    private void Awake()
    {
        _storyText = new Queue<string>();
        nameText.GetComponent<Text>().font = mainFont;
        dialogueText.GetComponent<Text>().font = mainFont;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        loadScene = false;
        animator.SetBool(IsOpened, true);
        _playerName = false;
        _storyText.Clear();
       

        foreach (string sentence in dialogue.sentences)
        {
            _storyText.Enqueue(sentence);

        }
        ShowNextSentence(dialogue);
    }

    public void StartCutscene(Dialogue dialogue)
    {
        cutscene.SetBool(IsCutscene, true);
        animator.SetBool(IsOpened, true);
        _playerName = false;
        _storyText.Clear();
        _timer = true;

        foreach (string sentence in dialogue.sentences)
        {
            _storyText.Enqueue(sentence);

        }
        ShowNextSentence(dialogue);
    }

    public void ShowNextSentence(Dialogue dialogue)
    {
        if (_storyText.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (_playerName)
        {
            nameText.text = dialogue.swapName;
            _playerName = false;
        }
        else
        {
            nameText.text = dialogue.name;
            _playerName = true;
        }
        string sentence = _storyText.Dequeue();
        dialogueText.text = sentence;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void EndDialogue()
    {
        loadScene = true;
        if (loadScene)
        {
            NextScene();
        }
        Debug.Log("End");
        if (GameObject.Find("Brother").GetComponentInChildren<DialogueTrigger>().cutscene)
        {
            GameObject.Find("Brother").transform.SetPositionAndRotation(new Vector3(-13.06f,1.48f,33.54f), transform.rotation);
            pistol.SetActive(true);
            Debug.Log("happens");
        }
        animator.SetBool(IsOpened, false);
        cutscene.SetBool(IsCutscene, false);
        FindObjectOfType<PlayerMovement>().walkingSpeed = 7.5f;
    }
    void NextScene()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Start_Dialogue"))
        {
            SceneManager.LoadScene("Main_Scene");
        }
    }

    private void Update()
    {
        if(_timer)
        {
            Timer();
            if (timeLeft < 0)
            {
                canEquipPistol = true;
            }
        }
    }

    private void Timer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
    }
}


