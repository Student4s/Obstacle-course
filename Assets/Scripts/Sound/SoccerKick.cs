using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerKick : MonoBehaviour
{
    private AudioSource audios;
    void Start()
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
