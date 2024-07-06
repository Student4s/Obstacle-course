using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyWheel : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float stopRotateSpeed;
    public bool isRotate=false;

    private float rotateSpeed2;
    public LuckyWheelPointer pointer;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Text winPanelText;
    [SerializeField] private Image winImage;
    [SerializeField] private GameObject nospinPanelText;

    public bool isFreespin = true;
    [SerializeField] private float timeBetweenFreeSpin;
    [SerializeField] private float currenttimeBetweenFreeSpin;
    [SerializeField] private Text freespins;
    [SerializeField] private Text countOfSpins;

    public Shop shop;

    private void Start()
    {
        rotateSpeed = Random.Range(300, 600);
        rotateSpeed2 = rotateSpeed;
        countOfSpins.text = "Spins: " +shop.spinCount.ToString();
    }

    public void Update()
    {
        if(isRotate)
        {
            if(rotateSpeed2>0)
            {
                transform.Rotate(0, 0, rotateSpeed2 * Time.deltaTime);
                rotateSpeed2 -= Time.deltaTime * stopRotateSpeed;
            }
            else
            {
                rotateSpeed = Random.Range(300, 600);
                CheckPrize();
                isRotate = false;
                rotateSpeed2 = rotateSpeed;
            } 
        } 

        if(!isFreespin)
        {
            currenttimeBetweenFreeSpin-=Time.deltaTime;
            if(currenttimeBetweenFreeSpin<=0)
            {
                isFreespin = true;
                currenttimeBetweenFreeSpin = timeBetweenFreeSpin;
                freespins.text = "You have 1 Free Spin!";
            }
        }

    }

    public void CheckPrize()
    {
        winPanel.SetActive(true);
        winPanelText.text = "You win "+pointer.prizeName;
        winImage.sprite = pointer.prizeImage;

        if(pointer.prizeName=="1x Mount")
        {
            shop.mountCount += 1;
        }
        if (pointer.prizeName == "1x Pit")
        {
            shop.pitCount += 1;
        }
        if (pointer.prizeName == "1x Rain")
        {
            shop.rainCount += 1;
        }
        if (pointer.prizeName == "1x Springboard")
        {
            shop.springboardCount += 1;
        }
        if (pointer.prizeName == "200")
        {
            shop.money += 200;
        }
        shop.UpdateCounts();
    }

    public void StartRotate()
    {
        if(!isRotate)
        {
            if (isFreespin)
            {
                isFreespin = false;
                freespins.text = "You have 0 Free Spin!";
                isRotate = true;
            }
            else
            {
                if (shop.spinCount > 0)
                {
                    shop.spinCount -= 1;
                    shop.UpdateCounts();
                    isRotate = true;
                    countOfSpins.text = shop.spinCount.ToString();
                }
                else
                {
                    nospinPanelText.SetActive(true);
                }
            }
        }

    }

}
