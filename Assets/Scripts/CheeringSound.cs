using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeringSound : MonoBehaviour
{
    private AudioSource audios;
    void Start()
    {
        audios = gameObject.GetComponent<AudioSource>();
    }

    public void Play()
    {
        audios.Play();
    }
}
