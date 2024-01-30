using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNclick : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Scene1");
    }
}
