using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plaza_door : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    private bool canMove;
    private Vector3 doorLClosePosition;
    private Vector3 doorRClosePosition;

    [SerializeField] private float openSpeed;

    private Camera mainCamera;
    
    void Awake()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not found in the scene!");
        }
    }

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
                    if(hit.collider.gameObject.CompareTag("SelectableBtn"))
                    {
                        Debug.Log("btn click");
                        canMove = true;
                        StartCoroutine(OpenAndCloseDoor());
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

        while(doorL.transform.position.x < 1040 && doorR.transform.position.x > -1050)
        {
            yield return null;
        }
        StartCoroutine(CloseDoorAfterDelay(6f));
    }
    void DoorOpen()
    {
        if(doorL.transform.position.x < 1040 && doorR.transform.position.x >= -1050)
        {
            doorL.transform.Translate(Vector3.left * Time.deltaTime * openSpeed);
            doorR.transform.Translate(Vector3.right * Time.deltaTime * openSpeed);
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
        doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, doorRClosePosition, openSpeed * Time.deltaTime);
        canMove = false;
    }
}