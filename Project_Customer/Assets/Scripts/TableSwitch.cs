using UnityEngine;
using UnityEngine.SceneManagement;

public class TableSwitch : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement _playerMovement;
    
    public GameObject fakePistol;
    
    public GameObject ammoBox;
    private AmmoSwitch _ammoSwitch;
    private void Start()
    {
       _playerMovement = player.GetComponent<PlayerMovement>();
       _ammoSwitch = ammoBox.GetComponent<AmmoSwitch>();
    }
    void OnMouseOver()
    {
        if (gameObject.CompareTag("GunBox") && Input.GetKeyDown(KeyCode.E) && _ammoSwitch.hasAmmo)
        {
            SceneManager.LoadScene("GameWin");
        }
        
        if(Input.GetKeyDown(KeyCode.E) && _playerMovement.hasPistol)
        {
            _playerMovement.pistol.SetActive(false);
            fakePistol.SetActive(true);
            _playerMovement.hasPistol = false;
        }
        else if(Input.GetKeyDown(KeyCode.E) && !_playerMovement.hasPistol)
        {
            _playerMovement.pistol.SetActive(true);
            fakePistol.SetActive(false);
            _playerMovement.hasPistol = true;
        }
        
    }
}
