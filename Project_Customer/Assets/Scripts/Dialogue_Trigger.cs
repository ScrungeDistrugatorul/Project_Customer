using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject currentNPC;
    public bool triggering;

    public bool cutscene = false;
    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogue);
        FindObjectOfType<Player_Movement>().walkingSpeed = 0f;
    }

    public void TriggerCutsceneDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().StartCutscene(dialogue);
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
                if (cutscene)
                {
                    TriggerCutsceneDialogue();
                }
                else
                {
                    TriggerDialogue();
                }
               
            }
            if (Input.GetMouseButtonDown(0) && FindObjectOfType<Player_Movement>().walkingSpeed == 0f)
            {
                NextSentence();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (this.gameObject.tag == "Cutscene")
            {
                cutscene = true;
                Debug.Log(cutscene);
            }
            triggering = true;
            currentNPC = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (this.gameObject.tag == "Cutscene")
            {
                cutscene = false;
            }
            triggering = false;
            currentNPC = null;
        }
    }
}
