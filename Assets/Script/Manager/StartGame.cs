using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject TitleText;
    [SerializeField] GameObject StartText;
    [SerializeField] GameObject DifficultySelect;
    [SerializeField] Animator FadeInFadeOut;
    [SerializeField] Animator DoorObject;

    private void Start()
    {
        GameManager.instance.pauseMenu.OpenMainMenuButton();
        AudioManager.instance.PlayNewBgm(AudioManager.Bgm.main);
    }
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }

    public void ResumeScene()//씬을 다시 시작
    {
        LoadScene("InGame");
    }

    public void ExitInGameScene()//메인메뉴 나가기
    {
        LoadScene("Title");
    }

    public void OnStartButton()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
        StartText.SetActive(false);
        DifficultySelect.SetActive(true);
    }

    public void OnButtonClickEasy()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
        GameManager.instance.SetDifficulty(0);
        StartCoroutine(StartThisGame());
    }

    public void OnButtonClickNormal()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
        GameManager.instance.SetDifficulty(1);
        StartCoroutine(StartThisGame());
    }

    public IEnumerator StartThisGame()
    {
        TitleText.SetActive(false);
        StartText.SetActive(false);
        DifficultySelect.SetActive(false);
        DoorObject.SetBool("Open", true);
        yield return new WaitForSeconds(1f);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.open_door);
        FadeInFadeOut.SetBool("Open", true);
        yield return new WaitForSeconds(1f);
        LoadScene("InGame");
    }
}
