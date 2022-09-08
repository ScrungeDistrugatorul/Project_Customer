using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Choice : MonoBehaviour
{
    public GameObject player;
    public GameObject choice;
    public GameObject choice2;
    private void OnMouseDown()
    {
        player.GetComponent<Player_Movement>().walkingSpeed = 7.5f;
        choice.SetActive(false);
        choice2.SetActive(false);
    }
}
