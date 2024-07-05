using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyWheelPointer : MonoBehaviour
{
    public bool isStop=false;
    public string prizeName;
    public Sprite prizeImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if(collision.GetComponent<LuckyWheelTile>() != null)
        {
            prizeName = collision.GetComponent<LuckyWheelTile>().prizeName;
            prizeImage = collision.GetComponent<LuckyWheelTile>().image;
        }
    }
}
