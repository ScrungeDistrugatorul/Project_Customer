using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_Switch : MonoBehaviour
{
    public GameObject player;
    public GameObject fakePistol;
    private Player_Movement playerMovement;
    private void Start()
    {
       playerMovement = player.GetComponent<Player_Movement>();
    }
    void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerMovement.hasPistol)
        {
            playerMovement.pistol.SetActive(false);
            fakePistol.SetActive(true);
            playerMovement.hasPistol = false;
        }
        else if(Input.GetKeyDown(KeyCode.E) && !playerMovement.hasPistol)
        {
            playerMovement.pistol.SetActive(true);
            fakePistol.SetActive(false);
            playerMovement.hasPistol = true;
        }
    }
}
