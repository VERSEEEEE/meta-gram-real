using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlazaToElevator : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Go to Elevator ...");
        SceneManager.LoadScene("Elevator");
    }
}

