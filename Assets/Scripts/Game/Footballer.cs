using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Footballer : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float coef;
    public float acceleration;
    public bool isPlayer = false;
    [SerializeField] private Sprite playerSprite;


    [SerializeField] private int mountain;
    [SerializeField] private int springboard;
    [SerializeField] private int rain;

    public delegate void StopAll();
    public static event StopAll Stops;

    public delegate void StopAll2(Transform pos, bool isPlayer);
    public static event StopAll2 Stops2;

    private void OnEnable()
    {
        Footballer.Stops += Stop;
    }
    private void OnDisable()
    {
        Footballer.Stops -= Stop;
    }
    void Start()
    {
        speed = speed* Random.Range(1-coef, 1 + coef);
        acceleration = acceleration * Random.Range(1 - coef, 1 + coef);
        if(isPlayer)
        {
            gameObject.GetComponent<Image>().sprite = playerSprite;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, (1*speed*Time.fixedDeltaTime)*(springboard+1)/(mountain+1+rain), 0);
        if(speed<maxSpeed)
        {
            speed += acceleration * Time.fixedDeltaTime;
        }
    }

    public void Stop()
    {
        speed = 0;
        acceleration = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndLine"))
        {
            Stop();
            Stops();
            Stops2(transform, isPlayer);
        }
    }

    public void SetMountain1()
    {
        mountain = 1;
    }
    public void SetMountain0()
    {
        mountain = 0;
    }
    public void SetSpringboard1()
    {
        springboard = 1;
    }
    public void SetSpringboard0()
    {
        springboard = 0;
    }
    public void SetRain1()
    {
        rain = 1;
    }
}
