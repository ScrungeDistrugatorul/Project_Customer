using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Changing_Text : MonoBehaviour, IPointerClickHandler
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Text1.activeSelf == true)
        {
            Text1.SetActive(false);
            Text2.SetActive(true);
        }
        else if (Text2.activeSelf == true)
        {
            Text2.SetActive(false);
            Text3.SetActive(true);
        }
        else if (Text3.activeSelf == true)
        {
            Text3.SetActive(false);
            Text4.SetActive(true);
        }
        else if (Text4.activeSelf == true)
        {
            Text4.SetActive(false);
            SceneManager.LoadScene("Main_Scene");
        }
    }
}
