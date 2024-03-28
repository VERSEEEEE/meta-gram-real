using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
    // public Animator anim;
    public GameObject hair1;
    public GameObject hair2;
    public GameObject hair3;
    // Start is called before the first frame update
    void Start()
    {
        hair1.SetActive(true);
        hair2.SetActive(false);
        hair3.SetActive(false);
    }
    void Update()
    {
        HairControlCheck();
    }
    // Update is called once per frame
    public void HairControlCheck()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            // anim.SetTrigger("hair1");
            hair1.SetActive(true);
            hair2.SetActive(false);
            hair3.SetActive(false);
            Debug.Log("hair1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)){
            // anim.SetTrigger("hair2");
            hair1.SetActive(false);
            hair2.SetActive(true);
            hair3.SetActive(false);
            Debug.Log("hair2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)){
            // anim.SetTrigger("hair3");
            hair1.SetActive(false);
            hair2.SetActive(false);
            hair3.SetActive(true);
            Debug.Log("hair3");
        }
    }
}
