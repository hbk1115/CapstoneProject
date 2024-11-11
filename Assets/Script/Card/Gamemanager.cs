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
            instance = this; // 인스턴스 설정
            DontDestroyOnLoad(gameObject); // 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 존재하면 현재 오브젝트를 파괴
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
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("호미");
        Player.instance.GenerateCard("성냥");
        Player.instance.GenerateCard("성냥");
        Player.instance.GenerateCard("성냥");
        Player.instance.GenerateCard("성냥");

        UIManager.instance.SetMapUI(true);
        AudioManager.instance.PlayNewBgm(AudioManager.Bgm.inBattle);
    }

    public void SetDifficulty(int num)
    {
        difficulty = num;
    }

    public int GetDifficulty() { return difficulty; }
}