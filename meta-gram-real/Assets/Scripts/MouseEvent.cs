using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    bool click = true;
    Vector3 destination = new Vector3(-1.5f, -3f, -9f);
    Vector3 currentPosition;
    Vector3 originScale;
    void Start()
    {
        currentPosition = transform.position;
        originScale = transform.localScale;
    }
   
    void Update()
    {
        if(click == true){
            if(Input.GetMouseButtonDown(0) && gameObject.tag == "Feed")
            {    
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))  
                {
                    if(hit.collider.gameObject.CompareTag("Feed"))
                    {
                        transform.position = Vector3.MoveTowards(transform.position, destination, 1);
                        transform.localScale = new Vector3(0f, 2f, 2f);
                        click = false;
                    }
                }
            }
        }
        else if(click == false){
            if(Input.GetMouseButtonDown(0))
            {
                resetAnim();
                click = true;
            }
        }
    }
    void resetAnim()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPosition, 1);
        transform.localScale = originScale;
       
    }
}

