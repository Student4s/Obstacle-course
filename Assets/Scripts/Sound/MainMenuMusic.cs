using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioSource audios;

    public AudioClip audio1;
    public AudioClip audio2;

    private void Start()
    {
        Main();
    }
    public void Main()
    {
        if (Save.GetSound() != 1)
        {
            audios.volume=0;
        }
        if (Save.GetSound() == 1)
        {
            audios.volume = 0.05f;
        }
        if (Save.GetMusic2() == 1)
        {
            audios.clip = audio2;
        }
        if (Save.GetMusic2() != 1)
        {
            audios.clip = audio1;
        }
        audios.Play();
    }
}
