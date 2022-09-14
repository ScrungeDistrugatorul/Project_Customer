using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Choices : MonoBehaviour
{
    public GameObject choice1;
    public GameObject choice2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            choice1.SetActive(true);
            choice2.SetActive(true);
        }
    }
}
