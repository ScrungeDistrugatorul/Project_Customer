using UnityEngine;
using UnityEngine.SceneManagement;

public class AutomaticStartText : MonoBehaviour
{
    public GameObject dialogueBox;
    private DialogueTrigger _dialogueTrigger;
    void Start()
    {
        _dialogueTrigger = dialogueBox.GetComponent<DialogueTrigger>();
        _dialogueTrigger.TriggerDialogue();
    }
}
