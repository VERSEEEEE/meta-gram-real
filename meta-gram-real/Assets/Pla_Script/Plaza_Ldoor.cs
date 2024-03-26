using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plaza_Ldoor : MonoBehaviour
{
    public GameObject doorL;
    private bool canMove;
    private Vector3 doorLClosePosition;

    [SerializeField] private float openSpeed;
    

    void Start()
    {
        canMove = false;
        doorLClosePosition = doorL.transform.position;
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
                    if(hit.collider.gameObject.CompareTag("SelectableBtn"))
                    {
                        Debug.Log("Door Open");
                        canMove = true;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(OpenAndCloseDoor());
        }
    }

    IEnumerator OpenAndCloseDoor()
    {
        DoorOpen();

        while (doorL.transform.position.z < -2.1f)
        {
            yield return null;
        }
        StartCoroutine(CloseDoorAfterDelay(6f));
    }
    void DoorOpen()
    {
        if(doorL.transform.position.z >= -2.1f) 
        {
            doorL.transform.Translate(Vector3.right * Time.deltaTime * openSpeed);
        }
    }

    IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DoorClose();
    }
    void DoorClose()
    {
        doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, doorLClosePosition, openSpeed * Time.deltaTime);
        canMove = false;
    }
}