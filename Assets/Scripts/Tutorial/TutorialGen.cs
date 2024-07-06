using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGen : MonoBehaviour
{
    [SerializeField] private int roundCount;
    [SerializeField] private List<Footballer> footballers;
    [SerializeField] private Footballer player;
    [SerializeField] private Track[] tracks;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int prizeMoney;

    //UI-elements
    [SerializeField] private Text urScore;
    [SerializeField] private Text notUrScore;
    [SerializeField] private Text PrizeforGame;
    [SerializeField] private Text PrizeforTrackCount;
    [SerializeField] private Text Multiplierforroundscount;
    [SerializeField] private Text TotalPrizeCount;
    [SerializeField] private Image GoalPanel;

    [SerializeField] private Image MainWinPanel;
    [SerializeField] private Text prizeCount;

    [SerializeField] private GameObject tip13;
    [SerializeField] private GameObject rain1;
    [SerializeField] private GameObject rain2;

    [SerializeField] private ParticleSystem p1;
    [SerializeField] private ParticleSystem p2;
    [SerializeField] private ParticleSystem p3;
    private void OnEnable()
    {
        Ball.Goaal += ChangeScore;
    }
    private void OnDisable()
    {
        Ball.Goaal -= ChangeScore;
    }
    public void Stop()
    {
        Time.timeScale = 0;
    }
    public void Go()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        Save.SetFirstTime();
        prizeMoney = 1000;
        PrizeforGame.text = "200";
        PrizeforTrackCount.text = "300";
        Multiplierforroundscount.text = "2";
        TotalPrizeCount.text = "1000";
        //prizeCount.text = prizeMoney.ToString();
        Stop();
        Save.SetMoney(1000);
    }
    public void SetRain()
    {
        tracks[0].isRain = true;
        tracks[1].isRain = true;
        rain1.SetActive(true);
        rain2.SetActive(true);
    }

    public void ChangeScore(bool isPlayer)
    {
        if (isPlayer)
        {
            if (roundCount > 0)
            {
                GoalPanel.gameObject.SetActive(true);
                int A = int.Parse(urScore.text) + 1;
                urScore.text = A.ToString();
            }
            else
            {
                tip13.SetActive(true);
                MainWinPanel.gameObject.SetActive(true);
                p1.gameObject.SetActive(true);
                p2.gameObject.SetActive(true);
                p3.gameObject.SetActive(true);
                p1.Play();
                p2.Play();
                p3.Play();
            }
        }
        Stop();
    }

    public void Respawn()
    {
        roundCount -= 1;
        for (int i = 0; i < footballers.Count; i++)
        {
            footballers[i].gameObject.SetActive(true);
            footballers[i].coef = 0;
           footballers[i].transform.position = spawnPoints[i].position;
        }
        footballers[2].speed = 0.5f;
        footballers[2].acceleration = 0.1f;
        footballers[2].isPlayer = true;
        footballers[0].speed = 0.2f;
        footballers[1].speed = 0.2f;
        footballers[1].acceleration = 0.2f;
    }


}
