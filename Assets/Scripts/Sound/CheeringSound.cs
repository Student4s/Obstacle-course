using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeringSound : MonoBehaviour
{
    private AudioSource audios;
    void Awake()
    {
        audios = gameObject.GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (Save.GetSound() == 1)
        {
            audios.Play();
        }
    }
}
