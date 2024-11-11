using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameSceneController : MonoBehaviour
{
    static public InGameSceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // 인스턴스 설정
            DontDestroyOnLoad(gameObject); // 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 존재하면 현재 오브젝트를 파괴
        }
    }
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }

    public void RestartGame()//씬을 다시 시작
    {
        LoadScene("InGame");
        GameManager.instance.SetPauseFalse();
    }

    public void ResumeScene()
    {
        GameManager.instance.SetPauseFalse();
    }

    public void ExitInGameScene()//메인메뉴 나가기
    {
        LoadScene("Title");
        GameManager.instance.SetPauseFalse();
    }
}
