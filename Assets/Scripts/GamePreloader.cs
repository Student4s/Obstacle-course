using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreloader : MonoBehaviour
{

    public int roundCounts;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetCounts(int counts)
    {
        roundCounts=counts;
    }
}
