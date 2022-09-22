using UnityEngine;
using UnityEngine.UI;

public class CheckInteractable : MonoBehaviour
{
    [SerializeField] 
    private GameObject canvas;

    public GameObject player;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnMouseOver()
    {
        
        bool interactable = GetComponentInChildren<InteractableZone>().interactable;
        if (interactable && _playerMovement.hasPistol)
        {
            canvas.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        canvas.SetActive(false);
    }
}
