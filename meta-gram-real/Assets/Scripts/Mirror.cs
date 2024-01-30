using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mirror : MonoBehaviour
{
    public Camera GetCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) 
            {
                Debug.Log("Touched Object: " + hit.transform.name);
                
                // Check if the touched object's name is "Mirror"
                if (hit.transform.name == "Mirror")
                {
                    SceneManager.LoadScene("Mirror");
                }
            }
        }
    }
}
