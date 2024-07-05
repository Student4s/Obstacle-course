using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private Image popUpImage;
    [SerializeField] private Text popUpText;
    [SerializeField] private float maxTime = 3f;
    [SerializeField] private float currentTime;
    [SerializeField] private bool isActive=false;

    private void Start()
    {
        
    }
    void Update()
    {
        if (currentTime < 0)
        {
            currentTime = 0;
        }
        if(isActive)
        {
            currentTime -= Time.deltaTime;
            Color color = popUpImage.color;
            color.a = currentTime / maxTime;
            popUpText.color = color;
            popUpImage.color = color;
        }    

        if(currentTime < 0)
        {
            isActive = false;
        }
    }

    public void PopUpActivate()
    {
        currentTime = maxTime;
        isActive=true;
    }
}
