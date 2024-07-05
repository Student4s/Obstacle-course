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
    public static void SetMoney(int moneys)
    {
        int A = PlayerPrefs.GetInt(money);
        A += moneys;
        PlayerPrefs.SetInt(money, A);
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

}
