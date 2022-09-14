using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject currentNPC;
    private bool triggering;
    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogue);
    }
    private void NextSentence()
    {
        FindObjectOfType<Dialogue_Manager>().ShowNextSentence();
    }

    void Update()
    {
        if (triggering)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
            if (Input.GetMouseButtonDown(0))
            {
                NextSentence();
            }    
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = true;
            currentNPC = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            currentNPC = null;
        }
    }
}
