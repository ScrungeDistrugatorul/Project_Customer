using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [HideInInspector]
    public bool triggering;
    [HideInInspector]
    public bool cutscene;

    private bool _mainCharTalk;

    public AudioSource audioSource;
    public AudioClip npcTalk;
    public AudioClip mainCharacterTalk;
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
        if (dialogue.swapName=="Dad:" && !_mainCharTalk)
        {
            audioSource.PlayOneShot(mainCharacterTalk,Volume);
            _mainCharTalk=true;
        }
        else
        {
            audioSource.PlayOneShot(npcTalk,Volume);
        }
    }


    void Update()
    {
        if (FindObjectOfType<PlayerMovement>().hasPistol) return;
        if (!triggering) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cutscene)
            {
                TriggerCutsceneDialogue();
                FindObjectOfType<DialogueManager>().GetComponent<AudioPlay>().enabled = false;
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
