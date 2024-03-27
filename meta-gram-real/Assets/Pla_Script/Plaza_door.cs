using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plaza_door : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    private bool canMove;
    [SerializeField] private float openSpeed;

    void Start()
    {
        canMove = false;
    }

    void Update()
    {
        if(!canMove)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.CompareTag("PlazaDoorBtn"))
                    {
                        Debug.Log("btn click");
                        canMove = true;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        Debug.Log("open");

        float startTime = Time.time; // 현재 시간 기록

        while (Time.time - startTime < 2f) // 시작 후 2초가 지날 때까지 반복
        {
            doorL.transform.Translate(Vector3.right * openSpeed * Time.deltaTime);
            doorR.transform.Translate(Vector3.left * openSpeed * Time.deltaTime);
            yield return null;
        }

        // 시간이 2초가 지나면 문이 열리는 동작을 멈춤
        DoorOpen(); 
        canMove = false;
    }

    void DoorOpen()
    {
        // Move the doors to fully open position
        doorL.transform.Translate(new Vector3(1102, 0, 0));
        doorR.transform.Translate(new Vector3(-1102, 0, 0));
    }
}