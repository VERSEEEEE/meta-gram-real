using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public GameObject tutorial;

    public float fadeSpeed = 0.5f;
    
    void Start()
    {
        tutorial.SetActive(true);
        InvokeRepeating("FadeOutTutorial", 2f, 0.005f);
    }

    // Update is called once per frame
    void FadeOutTutorial()
    {
        CanvasGroup canvasGroup = tutorial.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = tutorial.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha -= fadeSpeed * Time.deltaTime;

        if (canvasGroup.alpha <= 0)
        {
            canvasGroup.alpha = 0; 
            CancelInvoke("FadeOutTutorial"); 
            tutorial.SetActive(false); 
        }
    }
}
