using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    private Transform pointForBall;
    [SerializeField] private Ball ball;
    [SerializeField] private SoccerKick sound;


    private void OnEnable()
    {
        Footballer.Stops2 += Goal;
    }
    private void OnDisable()
    {
        Footballer.Stops2 -= Goal;
    }
    void Goal(Transform pos, bool isPlayer)
    {
        pointForBall = positions[Random.Range(0, positions.Length)];
        var A = Instantiate(ball, pos.position, pos.rotation);
        A.target = pointForBall;
        A.transform.parent = transform;
        A.isPlayer = isPlayer;
        sound.Play();
    }

}
