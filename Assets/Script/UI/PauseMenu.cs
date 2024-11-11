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

    public void OpenInGameButton()//���� ������ ����ϴ� �ٽ��ϱ�, ���� ���� ��ư Ȱ��ȭ
    {
        InGameButton.SetActive(true);
        MainMenuButton.SetActive(false);
    }
    public void OpenMainMenuButton()//���� ������ ����ϴ� �ٽ��ϱ�, ���� ���� ��ư Ȱ��ȭ
    {
        InGameButton.SetActive(false);
        MainMenuButton.SetActive(true);
    }
}
