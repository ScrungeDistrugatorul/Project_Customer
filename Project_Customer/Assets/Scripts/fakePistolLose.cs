using UnityEngine;
using UnityEngine.SceneManagement;

public class fakePistolLose : MonoBehaviour
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
        if (gameObject.activeSelf && !_ammoSwitch.hasAmmo)
        {
            SceneManager.LoadScene("Retry_Scene");
        }
    }
}