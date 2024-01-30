using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorDoor : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    private bool canMove;
    Vector3 doorLClosePosition;
    Vector3 doorRClosePosition;

    void Start()
    {
        canMove = false;
        doorLClosePosition = doorL.transform.position;
        doorRClosePosition = doorR.transform.position;
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
                    if(hit.collider.gameObject.CompareTag("Btn"))
                    {
                        doorOpen();
                    }
                }
            }
        }
        else
        {
            doorClose();
        }
        
    }
    public void doorOpen()
    {
        Debug.Log("버튼 클릭");
        while (doorL.transform.position.z >= -1.1f && doorR.transform.position.z <= 2.2f)
        {
            doorL.transform.Translate(Vector3.right * Time.deltaTime);
            doorR.transform.Translate(Vector3.left * Time.deltaTime);
        }
    }
    void doorClose()
    {
        if(doorL.transform.position.z <= -1.1f && doorR.transform.position.z >= 2.2f)
        doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, doorLClosePosition, 0.01f);
        doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, doorRClosePosition, 0.01f);
        canMove = false;
    }
}

