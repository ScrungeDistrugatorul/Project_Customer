using UnityEngine;
using UnityEngine.UI;

public class NpcHit : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement _playerMovement;
    [SerializeField] 
    private GameObject canvas;

    public GameObject currentNpc;
    private DialogueTrigger _dialogueTrigger;

    private void Start()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
        _dialogueTrigger = currentNpc.GetComponent<DialogueTrigger>();
    }

    private void OnMouseOver()
    {
        _playerMovement.npcIsHit = true;
        if (_dialogueTrigger.triggering)
        {
            canvas.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        _playerMovement.npcIsHit = false;
        canvas.SetActive(false);
    }
}
