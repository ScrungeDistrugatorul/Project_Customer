using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Game_Over : MonoBehaviour
{
    public GameObject choice;
    public GameObject choice2;
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Main_Scene");
        choice.SetActive(false);
        choice2.SetActive(false);
    }
}
