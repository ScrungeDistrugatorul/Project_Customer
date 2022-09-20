using UnityEngine;
using UnityEngine.SceneManagement;

public class FakePistolLose : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement _playerMovement;
    
    public GameObject ammoBox;
    private AmmoSwitch _ammoSwitch;

    private void Start()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
        _ammoSwitch = ammoBox.GetComponent<AmmoSwitch>();
    }
    private void OnBecameInvisible()
    {
        if (gameObject.activeSelf && _playerMovement.gunLoaded)
        {
            SceneManager.LoadScene("Retry_Scene");
        }
        else if (gameObject.activeSelf && _playerMovement.gunLoaded == false && _ammoSwitch.hasAmmo == false)
        {
            SceneManager.LoadScene("UnloadedRetryScene");
        }
    }
}
