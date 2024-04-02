using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorial;

    public float fadeSpeed = 0.5f;
    
    void Start()
    {
        tutorial.SetActive(true);
        Invoke("FadeOutTutorial", 2f);
    }

    // Update is called once per frame
    public void FadeOutTutorial()
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
            tutorial.SetActive(false); 
        }
    }
}
