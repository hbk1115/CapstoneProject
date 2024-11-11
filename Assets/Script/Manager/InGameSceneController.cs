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
            instance = this; // �ν��Ͻ� ����
            DontDestroyOnLoad(gameObject); // �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϸ� ���� ������Ʈ�� �ı�
        }
    }
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }

    public void RestartGame()//���� �ٽ� ����
    {
        LoadScene("InGame");
        GameManager.instance.SetPauseFalse();
    }

    public void ResumeScene()
    {
        GameManager.instance.SetPauseFalse();
    }

    public void ExitInGameScene()//���θ޴� ������
    {
        LoadScene("Title");
        GameManager.instance.SetPauseFalse();
    }
}
