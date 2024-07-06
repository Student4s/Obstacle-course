using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int money;
    public int mountCount;
    public int pitCount;
    public int springboardCount;
    public int rainCount;
    public int spinCount;
    [SerializeField] private GamePreloader preloader;
    public bool isBy4Lines = false;
    public bool isBy5Lines = false;
    public bool isByMusic = false;
    public bool isByPic = false;


    [SerializeField] private Text mountCounts;
    [SerializeField] private Text pitCounts;
    [SerializeField] private Text springboardCounts;
    [SerializeField] private Text rainCounts;
    [SerializeField] private Text moneyCounts;
    [SerializeField] private Text buy4Lines;
    [SerializeField] private GameObject buy4LinesCrutch;//убрать значок монетки 
    [SerializeField] private Text buy5Lines;
    [SerializeField] private GameObject buy5LinesCrutch;//убрать значок монетки 
    [SerializeField] private Text SpinCount;

    [SerializeField] private GameObject buyAltMusic;//убрать значок монетки 
    [SerializeField] private Text AltMusic;
    [SerializeField] private GameObject buyAltPic;//убрать значок монетки 
    [SerializeField] private Text AltPic;


    [SerializeField] private bool[] musicBuy;
    public PopUp pop;
    public LevelManager lvlManager;
    void Start()
    {
        if (Save.GetFirstTime() != 1)
        {
            Save.SetFirstTime();
            Saves();
        }
        money = Save.GetMoney();
        mountCount = Save.GetMounts();
        pitCount = Save.GetPits();
        springboardCount = Save.GetSpringboards();
        rainCount = Save.GetRains();
        spinCount = Save.GetSpins();
        if (Save.GetIsBy4Lines() == 1)
        {
            isBy4Lines = true;
            buy4Lines.text = "Buyed";
            buy4LinesCrutch.SetActive(false);
        }
        if (Save.GetIsBy5Lines() == 1)
        {
            isBy5Lines = true;
            buy4Lines.text = "Buyed";
            buy5LinesCrutch.SetActive(false);
        }
        if (Save.GetIsBy5Lines() == 1)
        {
            isBy5Lines = true;
            buy4Lines.text = "Buyed";
            buy5LinesCrutch.SetActive(false);
        }
        if (Save.GetMusic2() == 1)
        {
            isByMusic = true;
            AltMusic.text = "Buyed";
            buyAltMusic.SetActive(false);
        }
        if (Save.GetPic() == 1)
        {
            isByPic = true;
            AltPic.text = "Buyed";
            buyAltPic.SetActive(false);
        }
        UpdateCounts();
    }
    public void BuySkillMount(int price)
    {
        if (money >= price)
        {
            money -= price;
            mountCount += 1;
        }
        else
        {
            pop.PopUpActivate();
        }
        UpdateCounts();
    }
    public void BuySkillPit(int price)
    {
        if (money >= price)
        {
            money -= price;
            pitCount += 1;
        }
        else
        {
            pop.PopUpActivate();
        }
        UpdateCounts();
    }
    public void BuySkillRain(int price)
    {
        if (money >= price)
        {
            money -= price;
            rainCount += 1;
        }
        else
        {
            pop.PopUpActivate();
        }
        UpdateCounts();
    }
    public void BuySkillSpringboard(int price)
    {
        if (money >= price)
        {
            money -= price;
            springboardCount += 1;
        }
        else
        {
            pop.PopUpActivate();
        }
        UpdateCounts();
    }
    public void BuySpin(int price)
    {
        if (money >= price)
        {
            money -= price;
            spinCount += 1;
        }
        else
        {
            pop.PopUpActivate();
        }
        UpdateCounts();
    }
    public void Buy4Lines(int price)
    {
        if (money < price)
        {
            pop.PopUpActivate();
        }
        if (money >= price && !isBy4Lines)
        {
            money -= price;
            isBy4Lines = true;
        }
        UpdateCounts();
    }
    public void Buy5Lines(int price)
    {
        if (money < price)
        {
            pop.PopUpActivate();
        }
        if (money >= price && !isBy5Lines)
        {
            money -= price;
            isBy5Lines = true;
        }
        UpdateCounts();
    }
    public void BuyAltMusic(int price)
    {
        if (money < price)
        {
            pop.PopUpActivate();
        }
        if (money >= price && !isByMusic)
        {
            money -= price;
            isByMusic = true;
            Save.SetMusic2(1);
        }
        UpdateCounts();
    }
    public void BuyAltPic(int price)
    {
        if (money < price)
        {
            pop.PopUpActivate();
        }
        if (money >= price && !isByPic)
        {
            money -= price;
            isByPic = true;
            Save.SetBuyScreeSaver();
        }
        UpdateCounts();
    }

    public void GoTournamet(int tournamentPrice)
    {
        if (money < tournamentPrice)
        {
            pop.PopUpActivate();
        }
        if (money >= tournamentPrice)
        {
            money -= tournamentPrice;
            UpdateCounts();
        }
    }

    public void UpdateCounts()
    {
        mountCounts.text = mountCount.ToString();
        pitCounts.text = pitCount.ToString();
        springboardCounts.text = springboardCount.ToString();
        rainCounts.text = rainCount.ToString();
        moneyCounts.text = money.ToString();
        SpinCount.text = spinCount.ToString();

        if (isBy4Lines)
        {
            buy4Lines.text = "Buyed";
        }
        if (isBy5Lines)
        {
            buy5Lines.text = "Buyed";
        }
        if (isByMusic)
        {
            AltMusic.text = "Buyed";
        }
        if (isByPic)
        {
            AltPic.text = "Buyed";
        }
        Saves();
    }
    public void Saves()
    {
        int a = 0;
        int b = 0;
        if (isBy4Lines)
        {
            a = 1;
        }
        if (isBy5Lines)
        {
            b = 1;
        }
        Save.SetData(money, pitCount, mountCount, springboardCount, rainCount, a, b, spinCount);
    }
}
