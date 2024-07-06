using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Image soundOn;
    public Image soundOff;
    public Image defMusic;
    public Image altMusic;
    public Image defPic;
    public Image altPic;

    public MainMenuMusic music;
    void Start()
    {
        if(Save.GetSound()==1)
        {
            SoundOn();
        }
        else
        {
            SoundOff();
        }
        if(Save.GetMusic2()==1) { AltMusic(); }
        else
        {
            DeffMusic();
        }
        if (Save.GetPic() == 1) { AltPic(); }
        else
        {
            DefPic();
        }
    }

public void SoundOn()
    {
        Save.SetSound(1);
        soundOn.gameObject.SetActive(true);
        soundOff.gameObject.SetActive(false);
        music.Main();
    }
    public void SoundOff()
    {
        Save.SetSound(0);
        music.Main();
        soundOn.gameObject.SetActive(false);
        soundOff.gameObject.SetActive(true);
    }
    public void DeffMusic()
    {
        Save.SetMusic(0);
        music.Main();
        altMusic.gameObject.SetActive(false);
        defMusic.gameObject.SetActive(true);
    }
    public void AltMusic()
    {
        if(Save.GetMusic2()==1)
        {
            Save.SetMusic(1);
            music.Main();
            altMusic.gameObject.SetActive(true);
            defMusic.gameObject.SetActive(false);
        }
    }
    public void DefPic()
    {
        Save.SetPic(0);
        defPic.gameObject.SetActive(true);
        altPic.gameObject.SetActive(false);
    }
    public void AltPic()
    {
        if(Save.GetPicBuyed()==1)
        {
            Save.SetPic(1);
            defPic.gameObject.SetActive(false);
            altPic.gameObject.SetActive(true);
        }
    }

    public void AllReset()
    {
        Save.DeleteAllData();
        Save.SetMoneyZero();
        Save.SetFirstTimeZero();
    }
}
