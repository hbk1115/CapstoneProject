using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InRewardUI : BaseUI
{
    [SerializeField]
    private Button passButton;
    [SerializeField]
    private GameObject RewardUI;
    [SerializeField]
    private GameObject cardReward;

    private void Awake()
    {
        passButton.onClick.AddListener(() => RewardManager.instance.OnClickGainCard());
        //passButton.onClick.AddListener(() => RewardUI.SetActive(true));
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
