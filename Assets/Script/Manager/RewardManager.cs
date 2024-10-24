using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    static public RewardManager instance;

    [SerializeField]
    private BaseUI inRewardUI;
    [SerializeField]
    private GameObject cardRewardGameObject;
    [SerializeField]
    private GameObject rewardScreen;
    [SerializeField]
    private Transform rewardParent;
    [SerializeField]
    private Transform cardRewardParent;

    private Reward cardReward;

    [SerializeField]
    private Reward rewardPrefab;

    [SerializeField]
    private Sprite cardRewardImage;
    [SerializeField]
    private Sprite moneyRewardImage;

    private void Awake()
    {
        instance = this;
    }
    // ������ ����
    public void ShowReward()
    {
        // ���̶� ������
        rewardParent.DestroyAllChild();

        // ����â ���ֱ�
        //GameManager.UI.ShowThisUI(inRewardUI);
        inRewardUI.gameObject.SetActive(true);

        // ��
        Reward moneyReward = Instantiate(rewardPrefab, rewardParent);
        Button moneyRewardButton = moneyReward.GetComponent<Button>();
        int money = Random.Range(25, 37);
        moneyReward.Init(money + "���", moneyRewardImage);
        moneyRewardButton.onClick.AddListener(() => GetMoney(money));
        moneyRewardButton.onClick.AddListener(() => Destroy(moneyReward.gameObject));
    }


    public void ShowReward(BattleData battleData)
    {
        rewardParent.DestroyAllChild();
        cardRewardParent.DestroyAllChild();

        // ����â ���ֱ�
        //GameManager.UI.ShowThisUI(inRewardUI);
        inRewardUI.gameObject.SetActive(true);

        // ���� ������ ������ ī��� �ֱ� ������ ī��� �ϴ� ����
        GetCard();

        // ��
        Reward moneyReward = Instantiate(rewardPrefab, rewardParent);
        Button moneyRewardButton = moneyReward.GetComponent<Button>();
        int money = Random.Range(battleData.minMoney, battleData.maxMoney);
        moneyReward.Init(money + "���", moneyRewardImage);
        moneyRewardButton.onClick.AddListener(() => GetMoney(money));
        moneyRewardButton.onClick.AddListener(() => Destroy(moneyReward.gameObject));


        // ���� ī�� ����
        cardReward = Instantiate(rewardPrefab, rewardParent);
        Button cardRewardButton = cardReward.GetComponent<Button>();
        cardReward.Init("���� ī�带 �߰�", cardRewardImage);
        cardRewardButton.onClick.AddListener(() => cardRewardGameObject.gameObject.SetActive(true));
        cardRewardButton.onClick.AddListener(() => rewardScreen.gameObject.SetActive(false));

        // ���� ���鲨�� ���ǵ�
    }

    // ī�� 3�� ����
    private void GetCard()
    {
        BaseCard card1 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card2 = CardGenerator.instance.CreateCardFromRandom();
        BaseCard card3 = CardGenerator.instance.CreateCardFromRandom();

        card1.ChangeState(ECardUsage.Gain);
        card2.ChangeState(ECardUsage.Gain);
        card3.ChangeState(ECardUsage.Gain);

        card1.onClickAction = null;
        card2.onClickAction = null;
        card3.onClickAction = null;

        card1.onClickAction += (() => OnClickGainCard());
        card2.onClickAction += (() => OnClickGainCard());
        card3.onClickAction += (() => OnClickGainCard());

        card1.transform.SetParent(cardRewardParent);
        card2.transform.SetParent(cardRewardParent);
        card3.transform.SetParent(cardRewardParent);

        card1.transform.localScale = Vector3.one;
        card2.transform.localScale = Vector3.one;
        card3.transform.localScale = Vector3.one;
    }

    public void OnClickGainCard()
    {
        // ī�带 ���
        // ī�� ���� â�� �ݰ�
        // ī�� ������ ���ְ�

        cardRewardGameObject.gameObject.SetActive(false);
        rewardScreen.gameObject.SetActive(true);
        Destroy(cardReward.gameObject);
    }

    private void GetMoney(int value)
    {
        Player.instance.PlayerState.Money += value;
    }
}
