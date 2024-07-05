using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private int mountCount;
    [SerializeField] private int pitCount;
    [SerializeField] private int springboardCount;
    [SerializeField] private int rainCount;

    [SerializeField] private Text mountCounts;
    [SerializeField] private Text pitCounts;
    [SerializeField] private Text springboardCounts;
    [SerializeField] private Text rainCounts;

    [SerializeField] private Mount mount;
    [SerializeField] private Pit pit;
    [SerializeField] private Springboard springboard;

    [SerializeField] private GameGen gameGen;
    [SerializeField] private Transform field;

    void Start()
    {
        mountCount = Save.GetMounts();
        pitCount = Save.GetPits();
        springboardCount = Save.GetSpringboards();
        rainCount = Save.GetRains();
        UpdateCounts();
    }
    
    public void UseMount()
    {
        if(mountCount>=1)
        {
            Instantiate(mount, field);
        }
        mountCount -= 1;
        UpdateCounts();
    }
    public void UsePit()
    {
        if (pitCount >= 1)
        {
            Instantiate(pit, field);
        }
        pitCount -= 1;
        UpdateCounts();
    }
    public void UseSpringboard()
    {
        if (springboardCount >= 1)
        {
            Instantiate(springboard, field);
        }
        springboardCount -= 1;
        UpdateCounts();
    }
    public void UseRain()
    {
        if (rainCount >= 1)
        {
            gameGen.SetRain();
        }
        rainCount -= 1;
        UpdateCounts();
    }

    void UpdateCounts()
    {
        mountCounts.text = mountCount.ToString();
        pitCounts.text = pitCount.ToString();
        springboardCounts.text = springboardCount.ToString();
        rainCounts.text = rainCount.ToString();
        var a = Save.GetMoney();// затычка, чтобы не нужно было писать новую функцию.
        var b = Save.GetIsBy4Lines();
        var c = Save.GetIsBy5Lines();
        var c1 = Save.GetSpins();
        Save.SetData(a, pitCount, mountCount, springboardCount, rainCount,b,c,c1);
    }
}
