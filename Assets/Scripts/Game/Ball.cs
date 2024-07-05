using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Ball : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float moveSpeed = 3f;
    public float moveSpeedRight = 0.2f;// смещение вбок
    public Transform target;
    public float shrinkRate = 0.2f;

    public bool isPlayer;

    public delegate void Goals(bool player);
    public static event Goals Goaal;



    private void Start()
    {
        transform.localScale = Vector3.one;
    }
    void Update()
    {
        transform.localScale -= new Vector3(shrinkRate, shrinkRate, shrinkRate) * Time.deltaTime;// м€ч слегка уменьшаетс€ в полете, чтобы было немного реалистично.
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
       // transform.Translate(Vector3.right * moveSpeedRight * Time.deltaTime);

        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Goaal(isPlayer);
            Destroy(gameObject);
        }
    }
}
