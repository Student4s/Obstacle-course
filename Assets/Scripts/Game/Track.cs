using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public bool isRain;
    public GameObject rainIcon;


    public void OnTriggerStay2D(Collider2D collision)
    {
        if(isRain)
        {
            if (collision.GetComponent<Footballer>() != null)
            {
                collision.GetComponent<Footballer>().SetRain1();
            }
        }
    }
}
