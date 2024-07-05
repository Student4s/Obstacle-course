using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameStopper : MonoBehaviour
{
    public TutorialGen tutor;
    public GameObject tipPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Footballer>() != null)
        {
            tutor.Stop();
            tipPanel.SetActive(true);
            Destroy(gameObject);
        }

    }
}
