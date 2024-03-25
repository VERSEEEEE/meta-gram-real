using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickCarpet2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Carpet Clicked");
        SceneManager.LoadScene("furnitureChange");
    }
}

