using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreenSaver : MonoBehaviour
{
    public Image screenSaver;
    public Sprite s1;
    public Sprite s2;
    void Start()
    {
        if(Save.GetPic()==1)
        {
            screenSaver.sprite = s2;
        }
    }

}
