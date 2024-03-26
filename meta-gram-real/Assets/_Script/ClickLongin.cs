using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    SceneEffect_Simple sceneEffect;

    void Start()
    {
        sceneEffect = FindObjectOfType<SceneEffect_Simple>();
    }

    public void LoadPlazaScene()
    {
        sceneEffect.FadeToScene("Plaza_verse");
    }
}

