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

        while(doorL.transform.position.x < 1200f || doorR.transform.position.x > -1200f)
        {
            doorL.transform.Translate(Vector3.right * openSpeed * Time.deltaTime);
            doorR.transform.Translate(Vector3.left * openSpeed * Time.deltaTime);
            yield return null;
        }
    }
    void DoorOpen()
    {
        // if(doorL.transform.position.x <= 1200f && doorR.transform.position.x >= -1200f)
        // {
        //     doorL.transform.Translate(Vector3.right * Time.deltaTime * openSpeed);
        //     doorR.transform.Translate(Vector3.left * Time.deltaTime * openSpeed);
        // }
        // Debug.Log("open");
        doorL.transform.Translate(new Vector3(1102, 0, 0));
        doorR.transform.Translate(new Vector3(-1102, 0, 0));
    }
}