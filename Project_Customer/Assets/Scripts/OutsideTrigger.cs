using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideTrigger : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement _playerMovement;
    private void Start()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && _playerMovement.hasPistol)
        {
            SceneManager.LoadScene("Outside_Retry_Scene");
        }
    }
}
