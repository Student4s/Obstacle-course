using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RainMusic : MonoBehaviour
{
    private AudioSource audios;
    private float time = 4;
    private bool isPlay = false;
    void Start()
    {
        audios = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(isPlay)
        {
            time-= Time.deltaTime;
        }
        if(time<0)
        {
            isPlay = false;
            time = 4f;
            audios.Stop();
        }
    }
    public void Play()
    {
        if(Save.GetSound()==1)
        {
            audios.Play();
            isPlay = true;
        }
        
    }
}
