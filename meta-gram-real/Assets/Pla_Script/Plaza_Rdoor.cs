using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Plaza_Rdoor : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) == true) // open
        {
            gameObject.transform.position = new Vector3(-41022, 1040, 7739);
        }
 
        if (Input.GetKey(KeyCode.Alpha2) == true) // close
        {
            gameObject.transform.position = new Vector3(-40307, 1040, 7739);
        }
    }
}
 