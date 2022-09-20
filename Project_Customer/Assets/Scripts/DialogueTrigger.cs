using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [HideInInspector]
    public bool triggering;
    [HideInInspector]
    public bool cutscene;

    public AudioSource audioSource;
    public AudioClip npcTalk;
    private const float Volume = 0.2f;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<PlayerMovement>().walkingSpeed = 0f;
        audioSource.PlayOneShot(npcTalk,Volume);
    }

    public void TriggerCutsceneDialogue()
    {
        FindObjectOfType<DialogueManager>().StartCutscene(dialogue);
        FindObjectOfType<PlayerMovement>().walkingSpeed = 0f;
    }
    public void NextSentence()
    {
        FindObjectOfType<DialogueManager>().ShowNextSentence(dialogue);
        audioSource.PlayOneShot(npcTalk,Volume);
    }


    void Update()
    {
        if (!triggering) return;
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
        if (Input.GetMouseButtonDown(0) && FindObjectOfType<PlayerMovement>().walkingSpeed == 0f)
        {
            NextSentence();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (gameObject.CompareTag("Cutscene"))
        {
            cutscene = true;
            Debug.Log(cutscene);
        }
        triggering = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (gameObject.CompareTag("Cutscene"))
        {
            cutscene = false;
        }
        triggering = false;
    }
}
