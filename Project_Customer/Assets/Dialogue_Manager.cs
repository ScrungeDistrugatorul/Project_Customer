using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> storyText;
    // Start is called before the first frame update
    void Start()
    {
        storyText = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpened", true);
        nameText.text = dialogue.name;
        storyText.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            storyText.Enqueue(sentence);

        }
        ShowNextSentence();
    }

    public void ShowNextSentence()
    {
        if (storyText.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = storyText.Dequeue();
        dialogueText.text = sentence;
        Debug.Log("show");
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpened", false);
    }
}
