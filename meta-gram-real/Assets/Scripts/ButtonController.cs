using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject chatPanel;
    public GameObject writingPanel;
    public GameObject newPostPanel;

    private bool isSettingPanelActive = false;
    private bool isChatPanelActive = false;

    public void ControlChat() {
        if (isChatPanelActive)
        {
            chatPanel.SetActive(false);
            isChatPanelActive = false;
        }
        else
        {
            chatPanel.SetActive(true);
            isChatPanelActive = true;
        }
    }

    public void ControlSetting() {
        if (isSettingPanelActive)
        {
            settingPanel.SetActive(false);
            isSettingPanelActive = false;
        }
        else
        {
            settingPanel.SetActive(true);
            isSettingPanelActive = true;
        }
    }

    public void CloseWritingPanel() 
    {
        writingPanel.SetActive(false);
    }

    public void OpenNewPost() 
    {
        newPostPanel.SetActive(true);
    }

    public void CloseNewPost() 
    {
        newPostPanel.SetActive(false);
    }
}
