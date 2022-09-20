using UnityEngine;

public class NpcHit : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnMouseOver()
    {
        _playerMovement.npcIsHit = true;
    }
    private void OnMouseExit()
    {
        _playerMovement.npcIsHit = false;
    }
}
