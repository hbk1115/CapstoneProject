using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager instance;

    [Header("맵")]
    [SerializeField] public GameObject UI_Map;
    private bool map_Check = true;
    public GameObject doorObject;

    [Header("카드 정보")]
    [SerializeField] public GameObject CardInfo;

    [Header("보상 화면")]
    [SerializeField] public GameObject reward_UI;

    [Header("기타 UI")]
    [SerializeField] public GameObject Under_UI;

    [Header("카드 UI")]
    [SerializeField] public GameObject Card_UI;

    [Header("버튼 UI")]
    [SerializeField] public GameObject Button_UI;

    [Header("Fade_In_Out")]
    [SerializeField] public GameObject Fade_UI;

    [Header("게임 오버")]
    [SerializeField] public GameObject GameOverWindow;

    private void Awake()
    {
        instance = this;
    }

    public void SetMapUI(bool check)
    {
        UI_Map.SetActive(check);
        map_Check = check;
    }
    public void SetCarInfo(CardData cardData)
    {
        CardInfo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cardData.cardName;
        CardInfo.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cardData.cardDescription;
        CardInfo.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = cardData.cost.ToString();
    }

    public void OpenMapUI()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
        reward_UI.SetActive(false);
        UI_Map.SetActive(true);
    }

    public IEnumerator OpenDoor()
    {
        Under_UI.SetActive(false);
        Card_UI.SetActive(false);
        Button_UI.SetActive(false);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.open_door);

        doorObject.GetComponent<Animator>().SetBool("Open", true);//문 열림

        yield return new WaitForSeconds(1f);

        Fade_UI.GetComponent<Animator>().SetBool("Open", true);

        yield return new WaitForSeconds(1f);
    }

    public IEnumerator CloseDoor()
    {
        doorObject.GetComponent<Animator>().SetBool("Open", false);
        Fade_UI.GetComponent<Animator>().SetBool("Open", false);

        yield return new WaitForSeconds(2f);

        Under_UI.SetActive(true);
        Card_UI.SetActive(true);
        Button_UI.SetActive(true);
    }
    public void OpenGameOverWindow()
    {
        GameOverWindow.SetActive(true);
    }
}
