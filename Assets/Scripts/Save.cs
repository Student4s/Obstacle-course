using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Save : MonoBehaviour
{
    [SerializeField] private const string money="money";
    [SerializeField] private const string pitCount = "pitCount";
    [SerializeField] private const string mountCount = "mountCount";
    [SerializeField] private const string springboardCount = "springboardCount";
    [SerializeField] private const string rainCount = "rainCount"; 
    [SerializeField] private const string isBy4Lines = "isBy4Lines";
    [SerializeField] private const string isBy5Lines = "isBy5Lines"; 
    [SerializeField] private const string FirstTime = "FirstTime"; 
    [SerializeField] private const string Spins = "Spins"; 
    [SerializeField] private const string IsSound = "IsSound";//0-без звука, 1 - со звуком 
    //[SerializeField] private const string BuyMusic1 = "BuyMusic1";//базовая музыка. 0 - не установлено, 1 - установлено.
    [SerializeField] private const string BuyMusic2 = "BuyMusic2";//0-не купил, 1 - куплено
    [SerializeField] private const string Music2 = "Music2";//0 - не установлена альт. музыка, 1- установлена альт. музыка
    [SerializeField] private const string AltScreeSaver = "AltScreeSaver";//0 - не установлена альт. pic, 1- установлена альт. pic
    [SerializeField] private const string BuyScreeSaver = "BuyScreeSaver";//0 - не купил. pic, 1- купил
    public static void SetData(int moneys, int pits, int mounts, int springboard, int rains, int By4Lines, int By5Lines, int spins)
    {
        PlayerPrefs.SetInt(money, moneys);
        PlayerPrefs.SetInt(pitCount, pits);
        PlayerPrefs.SetInt(mountCount, mounts);
        PlayerPrefs.SetInt(springboardCount, springboard);
        PlayerPrefs.SetInt(rainCount, rains);
        PlayerPrefs.SetInt(isBy4Lines, By4Lines);
        PlayerPrefs.SetInt(isBy5Lines, By5Lines);
        PlayerPrefs.SetInt(Spins, spins);
        PlayerPrefs.Save();
    }
    public static void SetFirstTime()
    {
        PlayerPrefs.SetInt(FirstTime, 1);
    }
    public static void SetBuyScreeSaver()
    {
        PlayerPrefs.SetInt(BuyScreeSaver, 1);
    }
    public static void SetMoney(int moneys)
    {
        int A = PlayerPrefs.GetInt(money);
        A += moneys;
        PlayerPrefs.SetInt(money, A);
    }
    public static void SetSound(int sound)//0-без звука, 1 - со звуком 
    {
        PlayerPrefs.SetInt(IsSound, sound);
    }
   // public static void SetMusic1(int sound)
    //{
    //    PlayerPrefs.SetInt(BuyMusic1, sound);
    //}
    public static void SetMusic2(int sound)
    {
        PlayerPrefs.SetInt(BuyMusic2, sound);
    }
    public static void SetMusic(int sound)
    {
        PlayerPrefs.SetInt(Music2, sound);
    }
    public static void SetPic(int pic)
    {
        PlayerPrefs.SetInt(AltScreeSaver, pic);
    }
    public static int GetPicBuyed()
    {
        return PlayerPrefs.GetInt(BuyScreeSaver);
    }
    public static int GetPic()
    {
        return PlayerPrefs.GetInt(AltScreeSaver);
    }
    public static int GetMusic()
    {
        return PlayerPrefs.GetInt(Music2);
    }
    public static int GetSound()
    {
        return PlayerPrefs.GetInt(IsSound);
    }
   // public static int GetMusic1()
   // {
    //    return PlayerPrefs.GetInt(BuyMusic1);
   // }
    public static int GetMusic2()
    {
        return PlayerPrefs.GetInt(BuyMusic2);
    }
    public static int GetSpins()
    {
        return PlayerPrefs.GetInt(Spins);
    }
    public static int GetFirstTime()
    {
        return PlayerPrefs.GetInt(FirstTime);
    }
    public static int GetIsBy4Lines()
    {
        return PlayerPrefs.GetInt(isBy4Lines);
    }
    public static int GetIsBy5Lines()
    {
        return PlayerPrefs.GetInt(isBy5Lines);
    }
    public static int GetMoney()
    {
        return PlayerPrefs.GetInt(money);
    }
    public static int GetPits()
    {
        return PlayerPrefs.GetInt(pitCount);
    }
    public static int GetSpringboards()
    {
        return PlayerPrefs.GetInt(springboardCount);
    }
    public static int GetRains()
    {
        return PlayerPrefs.GetInt(rainCount);
    }
    public static int GetMounts()
    {
        return PlayerPrefs.GetInt(mountCount);
    }
    public static void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    //fOR TEST
    public static void SetMoneyZero()
    {
        PlayerPrefs.SetInt(money, 0);
    }
    public static void SetFirstTimeZero()
    {
        PlayerPrefs.SetInt(FirstTime, 0);
    }

}
