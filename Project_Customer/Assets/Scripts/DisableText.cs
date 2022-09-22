using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class DisableText : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private float timeLeft = 1f;
    private void OnEnable()
    {
        canvas.GetComponent<Text>().enabled = false;
        Timer();
    }

    private void Update()
    {
        if (canvas.GetComponent<Text>().enabled == false)
        {
            Timer();
            if (timeLeft <= 0)
            {
                canvas.SetActive(false);
                canvas.GetComponent<Text>().enabled = true;
            }
        }
    }

    private void Timer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
    }
}
