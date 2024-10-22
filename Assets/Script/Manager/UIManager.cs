using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager instance;

    [Header("��")]
    [SerializeField] public GameObject UI_Map;
    private bool map_Check = true;

    [Header("ī�� ����")]
    [SerializeField] public GameObject CardInfo;

    [Header("���� ȭ��")]
    [SerializeField] public GameObject reward_UI;

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
        reward_UI.SetActive(false);
        UI_Map.SetActive(true);
    }
}
