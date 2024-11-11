using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    [SerializeField] public PauseMenu pauseMenu;
    private bool pauseCheck = false;

    public int difficulty;

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
        
        pauseMenu.Init();
        difficulty = 0;
        //pauseMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseCheck)
            {
                SetPauseTrue();
            }
            else
            {
                SetPauseFalse();
            }
        }
    }

    public void SetPauseTrue()
    {
        Time.timeScale = 0f;
        pauseMenu.gameObject.SetActive(true);
        pauseCheck = true;
        AudioManager.instance.PauseBgm();
    }

    public void SetPauseFalse()
    {
        Time.timeScale = 1.0f;
        pauseMenu.gameObject.SetActive(false);
        pauseCheck = false;
        AudioManager.instance.ResumeBgm();
    }
    public void StartGame()
    {
        pauseMenu.OpenInGameButton();
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("ȣ��");
        Player.instance.GenerateCard("����");
        Player.instance.GenerateCard("����");
        Player.instance.GenerateCard("����");
        Player.instance.GenerateCard("����");

        UIManager.instance.SetMapUI(true);
        AudioManager.instance.PlayNewBgm(AudioManager.Bgm.inBattle);
    }

    public void SetDifficulty(int num)
    {
        difficulty = num;
    }

    public int GetDifficulty() { return difficulty; }
}