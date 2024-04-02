using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazaTutorialManager : MonoBehaviour
{
    public GameObject[] tutorials;
    private bool hasCollided = false;

    void Start()
    {
        DeactivateTutorials();
    }

    void Update() 
    {
        if(hasCollided)
        {
            enabled = false;
        }
        
    }

    void DeactivateTutorials()
    {
        for(int i = 0; i < tutorials.Length; i++)
        {
            tutorials[i].SetActive(false);
        }
    }

    void ActivateTutorials(GameObject tutorial)
    {
        tutorial.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        string collidedObjectName = other.gameObject.name;
        
         if (!hasCollided) 
        { 

            if (collidedObjectName == "wasdT")
            {
                ActivateTutorials(tutorials[0]);
            }
            else if (collidedObjectName == "cameraT")
            {
                ActivateTutorials(tutorials[1]);
            }
            else if (collidedObjectName == "zoomT")
            {
                ActivateTutorials(tutorials[2]);
                hasCollided = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DeactivateTutorials();

    }
}
