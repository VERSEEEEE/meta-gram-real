using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDoor : MonoBehaviour
{
    private void OnMouseDown() {
        FindObjectOfType<SceneEffect_Simple>().FadeToScene("Elevator");
    }
}
