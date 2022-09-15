using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    public Animator cutscene;

    private bool playerName;

    public GameObject pistol;

    private Queue<string> storyText;
    // Start is called before the first frame update
    void Start()
    {
        storyText = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpened", true);
        playerName = false;
        storyText.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            storyText.Enqueue(sentence);

        }
        ShowNextSentence(dialogue);
    }

    public void StartCutscene(Dialogue dialogue)
    {
        cutscene.SetBool("IsCutscene", true);
        animator.SetBool("IsOpened", true);
        playerName = false;
        storyText.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            storyText.Enqueue(sentence);

        }
        ShowNextSentence(dialogue);
    }

    public void ShowNextSentence(Dialogue dialogue)
    {
        if (playerName)
        {
            nameText.text = dialogue.swapName;
            playerName = false;
        }
        else
        {
            nameText.text = dialogue.name;
            playerName = true;
        }
        if (storyText.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = storyText.Dequeue();
        dialogueText.text = sentence;
        //Debug.Log("show");
    }

    void EndDialogue()
    {
        Debug.Log("End");
        if (GameObject.Find("Brother").GetComponentInChildren<Dialogue_Trigger>().cutscene)
        {

            GameObject.Find("Brother").transform.SetPositionAndRotation(new Vector3(2.9f, 1.5f, -12.7f), transform.rotation);
            pistol.SetActive(true);
            Debug.Log("happens");
        }
        animator.SetBool("IsOpened", false);
        cutscene.SetBool("IsCutscene", false);
        FindObjectOfType<Player_Movement>().walkingSpeed = 7.5f;
    }
}
