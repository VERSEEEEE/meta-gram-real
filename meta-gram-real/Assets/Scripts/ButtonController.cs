using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject chatPanel;

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
}
