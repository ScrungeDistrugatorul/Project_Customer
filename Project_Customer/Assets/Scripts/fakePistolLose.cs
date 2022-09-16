using UnityEngine;
using UnityEngine.SceneManagement;

public class FakePistolLose : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
    }
    private void OnBecameInvisible()
    {
        if (gameObject.activeSelf && _playerMovement.gunLoaded)
        {
            SceneManager.LoadScene("Retry_Scene");
        }
    }
}
