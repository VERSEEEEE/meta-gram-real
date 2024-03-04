using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameObject MainPanel; 
    public GameObject SignInPanel; 

    // Start is called before the first frame update
    void Start()
    {
       
        MainPanel.SetActive(true); 
         SignInPanel.SetActive(false); 
    }

    
    public void OnSignUpButtonClicked()
    {
        // Sign Up 버튼이 클릭되었을 때 호출됩니다.
        // MainPanel을 비활성화하고 SignInPanel을 활성화합니다.
        MainPanel.SetActive(false); 
        SignInPanel.SetActive(true); 
    }

    public void OnSignInButtonClicked()
    {
        // Sign In 버튼이 클릭되었을 때 호출됩니다.
        // SignInPanel을 활성화합니다.
        SignInPanel.SetActive(true); 
    }

    public void OnCloseSignInPanelButtonClicked()
    {
        // SignInPanel 내부의 닫기 버튼이 클릭되었을 때 호출됩니다.
        // SignInPanel을 비활성화합니다.
        SignInPanel.SetActive(false); 
    }
}
