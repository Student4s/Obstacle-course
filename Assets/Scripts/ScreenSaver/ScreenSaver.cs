using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSaver : MonoBehaviour
{
    public Slider progressBar; // Перетащите сюда ваш Slider из инспектора
    public float loadDuration; // Длительность загрузки в секундах

    private float timeElapsed;
    public LevelManager levelManager;

    void Start()
    {
        loadDuration = Random.Range(2f, 4f);
        // Начинаем с нуля
        progressBar.value = 0;
        timeElapsed = 0;
    }

    void Update()
    {
        if (timeElapsed < loadDuration)
        {
            timeElapsed += Time.deltaTime;
            progressBar.value = Mathf.Clamp01(timeElapsed / loadDuration);
        }
        else
        {
            if(Save.GetFirstTime()==1)
            {
                levelManager.LoadMenu();
            }
           else
            {
                levelManager.LoadTutorial();
            }
            
        }
    }
}
