using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioPlay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bulletshots;
    private const float Volume = 0.4f;

    public float timeLeft = 1f;

    // Update is called once per frame
    void Update()
    {
        Timer();
        if (timeLeft <= 0)
        {
            audioSource.PlayOneShot(bulletshots,Volume);
            timeLeft = Random.Range(1.5f, 3f);
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
