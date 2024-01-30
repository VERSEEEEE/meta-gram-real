using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject[] floors;
    public GameObject[] numbers;

    void Start()
    {
        InitilizeFloors();
    }

    // Start is called before the first frame update
    void InitilizeFloors()
    {
        for(int i = 0; i < floors.Length; i++)
        {
            floors[i].SetActive(false);
            Debug.Log(floors[i]);
        }
        floors[1].SetActive(true);
    }

    void ClickFloor(int newIndex)
    {
        for(int i = 0; i < floors.Length; i++)
        {
            floors[i].SetActive(false);
        }
        floors[newIndex].SetActive(true);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("No.1"))
                {
                    ClickFloor(1);
                }
                if(hit.collider.gameObject.CompareTag("No.2"))
                {
                    ClickFloor(2);
                }
                if(hit.collider.gameObject.CompareTag("No.3"))
                {
                    ClickFloor(3);
                }
                if(hit.collider.gameObject.CompareTag("No.4"))
                {
                    ClickFloor(4);
                }
                if(hit.collider.gameObject.CompareTag("No.5"))
                {
                    ClickFloor(5);
                }
                if(hit.collider.gameObject.CompareTag("No.6"))
                {
                    ClickFloor(6);
                }
                if(hit.collider.gameObject.CompareTag("No.7"))
                {
                    ClickFloor(7);
                }
                if(hit.collider.gameObject.CompareTag("No.8"))
                {
                    ClickFloor(8);
                }
                if(hit.collider.gameObject.CompareTag("No.9"))
                {
                    ClickFloor(9);
                }
            }
        }   
    }
}
