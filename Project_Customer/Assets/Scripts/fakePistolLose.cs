using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fakePistolLose : MonoBehaviour
{
    public GameObject player;
    private Player_Movement playerMovement;

    private void Start()
    {
        playerMovement = player.GetComponent<Player_Movement>();
    }
    private void OnBecameInvisible()
    {
        if (this.gameObject.activeSelf && playerMovement.gunLoaded)
        {
            SceneManager.LoadScene("Retry_Scene");
        }
    }
}
