using UnityEngine;
using UnityEngine.SceneManagement;

public class GunBoxRetry : MonoBehaviour
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
        if (gameObject.activeSelf && _playerMovement.gunLoaded && !_ammoSwitch.hasAmmo)
        {
            SceneManager.LoadScene("GunBoxRetry");
        }
        else if (gameObject.activeSelf && !_playerMovement.gunLoaded && !_ammoSwitch.hasAmmo)
        {
            SceneManager.LoadScene("Retry_Scene");
        }
    }
}
