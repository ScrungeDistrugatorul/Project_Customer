using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry_Btn : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
