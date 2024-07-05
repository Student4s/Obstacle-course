using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springboard : MonoBehaviour
{
    [SerializeField] private float posX;
    [SerializeField] private LayerMask layerToCheck;

    [SerializeField] private bool isUse = false;
    [SerializeField] private bool isCanUse = false;
    void Update()
    {
        if (Input.GetMouseButton(0) && !isUse)
        {
            //Двигаемся за курсором
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = transform.position.z;

            //Если под курсором дорожка - прилипаем к дорожке
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layerToCheck);
            if (hit.collider != null && hit.collider.CompareTag("Track"))
            {
               // Debug.Log(hit.collider.name);
                posX = hit.collider.transform.position.x;
                mousePosition.x = hit.collider.transform.position.x;
                transform.position = mousePosition;
                isCanUse = true;
            }
            else
            {
                transform.position = mousePosition;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isCanUse)
            {
                isUse = true;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Footballer>() != null)
        {
            collision.GetComponent<Footballer>().SetSpringboard1();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Footballer>() != null)
        {
            collision.GetComponent<Footballer>().SetSpringboard0();
        }
    }
}
