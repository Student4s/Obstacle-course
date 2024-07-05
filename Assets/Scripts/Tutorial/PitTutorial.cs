using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTutorial : MonoBehaviour
{
    [SerializeField] private float posX;
    [SerializeField] private LayerMask layerToCheck;

    public bool isUse = false;
    [SerializeField] private bool isCanUse = false;

    [SerializeField] private TutorialGen gen;
    //[SerializeField] private GameObject tipActivate;
    [SerializeField] private GameObject tipDesativate;

    void Update()
    {
        if (Input.GetMouseButton(0) && !isUse)
        {
            //��������� �� ��������
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = transform.position.z;

            //���� ��� �������� ������� - ��������� � �������
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, layerToCheck);
            if (hit.collider != null && hit.collider.CompareTag("tutorPit"))
            {
                posX = hit.collider.transform.position.x;
                mousePosition.x = hit.collider.transform.position.x;
                transform.position = mousePosition;
                isCanUse = true;
                //tipActivate.SetActive(true);
            }
            else
            {
                transform.position = mousePosition;
                isCanUse = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isCanUse)
            {
                isUse = true;
                tipDesativate.SetActive(false);
                gen.Go();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.GetComponent<Footballer>() != null && isUse)
        {
            Debug.Log("1");
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
