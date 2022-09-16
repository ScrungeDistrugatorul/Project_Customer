using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outsideTrigger : MonoBehaviour
{
    public GameObject player;
    private Player_Movement playerMovement;
    private void Start()
    {
        playerMovement = player.GetComponent<Player_Movement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player" && playerMovement.hasPistol)
        {
            SceneManager.LoadScene("Outside_Retry_Scene");
        }
    }
}
