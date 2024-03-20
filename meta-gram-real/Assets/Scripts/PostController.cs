using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostController : MonoBehaviour
{
    public GameObject writingPanel;
    public GameObject newPostPanel;
    public GameObject listContent;
    public GameObject postPanel;

    private string titleText;
    private string contentText;
    private GameObject addPost;
    private GameObject player;

    void Start() 
    {
        player = GameObject.Find("Player");
    }

    private void OnMouseDown() {
        OpenWritingPanel();
    }

    private void OpenWritingPanel() 
    {
        writingPanel.SetActive(true);
    }

    public void SavePost()
    {
        DeliverWriting();
        newPostPanel.SetActive(false);
    }

    private void DeliverWriting() 
    {
        GameObject post = Instantiate(postPanel) as GameObject;
        post.transform.SetParent(listContent.transform, false);

        titleText = newPostPanel.transform.GetChild(3).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text;
        post.transform.GetChild(2).GetComponent<TMP_Text>().text = titleText;

        contentText = newPostPanel.transform.GetChild(4).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text;
        post.transform.GetChild(3).GetComponent<TMP_Text>().text = contentText;

        newPostPanel.transform.GetChild(3).GetComponent<TMP_InputField>().text = "";
        newPostPanel.transform.GetChild(4).GetComponent<TMP_InputField>().text = "";
    }
}