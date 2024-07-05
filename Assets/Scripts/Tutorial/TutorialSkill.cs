using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TutorialSkill : MonoBehaviour
{
    [SerializeField] private int mountCount;
    [SerializeField] private int pitCount;
    [SerializeField] private int springboardCount;
    [SerializeField] private int rainCount;

    public bool isMount;
    public bool isPit;
    public bool isSpringboard;
    public bool isRain;

    [SerializeField] private Text mountCounts;
    [SerializeField] private Text pitCounts;
    [SerializeField] private Text springboardCounts;
    [SerializeField] private Text rainCounts;

    [SerializeField] private MoutTutorial mount;
    [SerializeField] private PitTutorial pit;
    [SerializeField] private SpringboardTutorial springboard;

    [SerializeField] private TutorialGen gameGen;
    [SerializeField] private Transform field;

    public GameObject tipPanel1;
    public GameObject tipPanelTodespawn1;
    public GameObject tipPanelTodespawn2;
    public GameObject square;

    private void Start()
    {
        UpdateInfo();
    }
    public void UseMount()
    {
        if (mountCount >= 1&& isMount)
        {
            tipPanelTodespawn2.SetActive(false);
            var A = Instantiate(mount, field);
            A.isUse = false;
            A.gameObject.transform.position = new Vector3(0, 0, A.gameObject.transform.position.z);
            mountCount -= 1;
        }
      
        UpdateInfo();
    }
    public void UsePit()
    {
        if (pitCount >= 1 && isPit)
        {
            var A = Instantiate(pit, field);
            A.isUse = false;
            A.gameObject.transform.position = new Vector3(0,0, A.gameObject.transform.position.z);
            pitCount -= 1;
        }
       
        UpdateInfo();
    }
    public void UseRain()
    {
        if (rainCount >= 1 && isRain)
        {
            gameGen.SetRain();
            tipPanel1.SetActive(true);
            tipPanelTodespawn1.SetActive(false);

            square.SetActive(true);
            rainCount -= 1;
        }
        
        UpdateInfo();
    }

    public void Mount()
    {
        isMount = true;
    }
    public void Pit()
    {
        isPit = true;
    }
    public void Rain()
    {
        isRain = true;
    }

    void UpdateInfo()
    {
        mountCounts.text = mountCount.ToString();
        pitCounts.text = pitCount.ToString();
        springboardCounts.text = springboardCount.ToString();
        rainCounts.text = rainCount.ToString();
    }
}
