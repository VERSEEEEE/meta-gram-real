using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private string nextSceneName;

    public void goToLongEffect1()
    {
        // 짧은 페이드 효과 사용법 - 각 사용법은 해당하는 인스턴스(검은색 이미지 등)가 있어야 하므로 일단 설정했던 대로 설정했음
        // 씬 전환마다 어떤 효과를 넣을지 생각하고 인스턴스 만들고 코드 적용
        // nextSceneName = "LongEffect1";
        // FindObjectOfType<SceneEffect_Simple>().FadeToScene(nextSceneName);

        // 긴 페이드 효과 사용법
        //nextSceneName = "LongEffect1";
        //SceneEffect_Long.Instance.ChangeScene(nextSceneName);
    }

    public void goToMirror() {
        nextSceneName = "Mirror";    // 옮길 씬 이름 넣기
        FindObjectOfType<SceneEffect_Simple>().FadeToScene(nextSceneName);

        // SceneManage.Instance.ChangeScene(nextSceneName);
    } 
}