using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Ball;


public class GameGen : MonoBehaviour
{
    [SerializeField] private int roundCount;
    [SerializeField] private List<Footballer> footballers;
    [SerializeField] private Footballer player;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Track[] tracks;
    [SerializeField] private int prizeMoney;//win
    [SerializeField] private int prizeMoney2;//lose

    //UI-elements
    [SerializeField] private Text urScore;
    [SerializeField] private Text notUrScore;
    //[SerializeField] private Text money;
    //win
    [SerializeField] private Text PrizeforGame;
    [SerializeField] private Text PrizeforTrackCount;
    [SerializeField] private Text Multiplierforroundscount;
    [SerializeField] private Text TotalPrizeCount;
    //lose
    [SerializeField] private Text TotalPrizeCount1;

    [SerializeField] private Image GoalPanel;
    [SerializeField] private Image MainWinPanel;
    [SerializeField] private Image MainLosePanel;

    [SerializeField] private RainMusic rain;
    [SerializeField] private CheeringSound sound;


    // [SerializeField] private bool isGame = false;// чтобы запускать нажатием по екрану
    private void OnEnable()
    {
        Ball.Goaal += ChangeScore;
    }
    private void OnDisable()
    {
        Ball.Goaal -= ChangeScore;
    }
    void Start()
    {
        GamePreloader[] gamePreloaders = FindObjectsOfType<GamePreloader>();

        if (gamePreloaders[0].roundCounts==4)
        {
            Destroy(gamePreloaders[0].gameObject);
            roundCount = gamePreloaders[1].roundCounts;
            gamePreloaders[1].roundCounts = 4;
        }
        else
        {
            roundCount = gamePreloaders[0].roundCounts;
            gamePreloaders[0].roundCounts=4;
        }
  
        prizeMoney = roundCount * (100 + 50*tracks.Length);
        prizeMoney2 = 100;
        TotalPrizeCount1.text = prizeMoney2.ToString();

        PrizeforGame.text = "100";
        PrizeforTrackCount.text = (50*tracks.Length).ToString();
        Multiplierforroundscount.text ="X"+ roundCount.ToString();
        TotalPrizeCount.text = prizeMoney.ToString();

        Respawn();
    }

    private void Update()
    {
        
    }

    public void ChangeScore(bool isPlayer)
    {
        sound.Play();
        if (isPlayer)
        {
            if(roundCount > 0)
            {
                GoalPanel.gameObject.SetActive(true);
                int A = int.Parse(urScore.text) + 1;
                urScore.text = A.ToString();
            }
            else
            {
                MainWinPanel.gameObject.SetActive(true);
                var a = Save.GetMoney()+ prizeMoney;
                var a1 = Save.GetPits();
                var a2 = Save.GetMounts();
                var a3 = Save.GetSpringboards();
                var a4 = Save.GetRains();
                var b = Save.GetIsBy4Lines();
                var c = Save.GetIsBy5Lines();
                var c1 = Save.GetSpins();
                Save.SetData(a, a1, a2, a3, a4, b, c,c1);
            }
            
        }
        else
        {
            if (roundCount > 0)
            {
                GoalPanel.gameObject.SetActive(true);
                int A = int.Parse(notUrScore.text) + 1;
                notUrScore.text = A.ToString();
            }
            else
            {
                MainLosePanel.gameObject.SetActive(true);
                var a = Save.GetMoney() + 100;
                var a1 = Save.GetPits();
                var a2 = Save.GetMounts();
                var a3 = Save.GetSpringboards();
                var a4 = Save.GetRains();
                var b = Save.GetIsBy4Lines();
                var c = Save.GetIsBy5Lines();
                var c1 = Save.GetSpins();
                Save.SetData(a, a1, a2, a3, a4, b, c,c1);
            }
            
        }
    }

    public void Respawn()
    {
        GoalPanel.gameObject.SetActive (false);
        if (roundCount>0)
        {
            for (int i = 0; i < footballers.Count; i++)
            {
                Destroy(footballers[i].gameObject);
            }

            int playerFootballer = Random.Range(0, footballers.Count);
            footballers.Clear();
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                var A = Instantiate(player, spawnPoints[i].position, spawnPoints[i].rotation);
                A.transform.parent = transform;
                A.transform.localScale = Vector3.one;
                if (i == playerFootballer)
                {
                    A.isPlayer = true;
                }
                footballers.Add(A);
            }
            roundCount -= 1;
        }
        for (int i = 0; i < tracks.Length; i++)
        {
            tracks[i].rainIcon.SetActive(false);
            tracks[i].isRain = false;
        }

    }
        
    public void SetRain()
    {
        rain.Play();
        int A = Random.Range(2, tracks.Length); 
        for (int i=0; i<10;i++)
        {
            int B = Random.Range(0, tracks.Length);
            if (!tracks[B].isRain)
            {
                tracks[B].isRain = true;
                tracks[B].rainIcon.SetActive(true);

                A -= 1;
                if(A<=0)
                {
                    return;
                }    
            }  
        }
    }
}
