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
        FindObjectOfType<Player_Movement>().walkingSpeed = 0f;
    }
    private void NextSentence()
    {
        FindObjectOfType<Dialogue_Manager>().ShowNextSentence(dialogue);
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
