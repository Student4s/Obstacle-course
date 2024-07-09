using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Shop shop;
    [SerializeField] private int tournamentPrice;
    public PopUp pop2;//4-5Lines

    public void Load3Lines()
    {
            SceneManager.LoadScene("GameX3");
    }

    public void Load4Lines()
    {
        if (shop.isBy4Lines)
        {
            SceneManager.LoadScene("GameX4");
        }
        else
        {
            pop2.PopUpActivate();
        }

    }

    public void Load5Lines()
    {
        if (shop.isBy5Lines)
        {
            SceneManager.LoadScene("GameX5");
        }
        else
        {
            pop2.PopUpActivate();
        }

    }
    public void LoadMenu()
    {
            SceneManager.LoadScene("MainMenu");
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadTournament1()
    {      
        if(shop.money>=300)
        {
            SceneManager.LoadScene("GameX3");
        }
    }
    public void LoadTournament2()
    {
        if (shop.isBy4Lines&& shop.money >= 500)
        {
            SceneManager.LoadScene("GameX4");
        }
        if(!shop.isBy4Lines)
        {
            pop2.PopUpActivate();
        }
    }
    public void LoadTournament3()
    {
        if (shop.isBy5Lines && shop.money >= 1000)
        {
            SceneManager.LoadScene("GameX5");
        }
        if (!shop.isBy5Lines)
        {
            pop2.PopUpActivate();
        }
    }
}
