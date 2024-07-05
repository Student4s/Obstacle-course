using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Shop shop;
    [SerializeField] private int tournamentPrice;

    public void Load3Lines()
    {
            SceneManager.LoadScene("GameX3");
    }

    public void Load4Lines()
    {
        if(shop.isBy4Lines)
        {
            SceneManager.LoadScene("GameX4");
        }
    }

    public void Load5Lines()
    {
        if (shop.isBy5Lines)
        {
            SceneManager.LoadScene("GameX5");
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
        SceneManager.LoadScene("GameX3");
    }
    public void LoadTournament2()
    {
        SceneManager.LoadScene("GameX4");
    }
    public void LoadTournament3()
    {
        SceneManager.LoadScene("GameX5");
    }
}
