using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchUIController : MonoBehaviour
{
    bool isClick;
    public GameObject searchPanel;

    // Start is called before the first frame update
    void Start()
    {
        isClick = false;
        searchPanel.SetActive(isClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("Search"))
                {
                    ShowUI();
                }
                else
                {
                    CloseUI();
                }
            }
        }
        
    }

    void ShowUI()
    {
        isClick = true;
        searchPanel.SetActive(isClick);
    }

    void CloseUI()
    {
        isClick = false;
        searchPanel.SetActive(isClick);
    }
}
