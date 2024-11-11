using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public Slider sfxSlider;
    [SerializeField] public Slider bgmSlider;

    [SerializeField] private GameObject InGameButton;
    [SerializeField] private GameObject MainMenuButton;
    public void Init()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OpenInGameButton()//게임 내에서 사용하는 다시하기, 게임 종료 버튼 활성화
    {
        InGameButton.SetActive(true);
        MainMenuButton.SetActive(false);
    }
    public void OpenMainMenuButton()//게임 내에서 사용하는 다시하기, 게임 종료 버튼 활성화
    {
        InGameButton.SetActive(false);
        MainMenuButton.SetActive(true);
    }
}
