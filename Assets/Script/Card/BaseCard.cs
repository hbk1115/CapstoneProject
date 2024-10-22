using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;

public enum ECardUsage
{
    Battle,   // ��Ʋ
    Check,    // Ȯ��
    Gain,     // ���
    Enforce,  // ��ȭ
    DisCard,  // ����
    Sell,     // �Ǹ�
}

public class BaseCard : MonoBehaviour
{
    [SerializeField]
    private CardController _cardController;

    public CardData cardData; // ī�� ������
    public Action onClickAction;

    private BaseCardStateFactory _baseCardStateFactory;

    public BaseCardState CurrentState => _baseCardStateFactory.CurrentState;
    public CardController CardController => _cardController;

    public void Init(Transform cardHolder, CardData data)
    {
        cardData = data;
        transform.SetParent(cardHolder);
        _baseCardStateFactory = new BaseCardStateFactory(this);

        _cardController.Init(this);
        // ī�� �̹����� ������ �����ϴ� ������ �߰��� �� �ֽ��ϴ�.
    }

    public bool Play(Player player)
    {
        if (player.CurrentEnergy < cardData.cost)
        {
            Debug.Log($"�ڽ�Ʈ�� �����մϴ�. �ʿ� �ڽ�Ʈ: {cardData.cost}, ���� ������: {player.CurrentEnergy}");
            return false; // �������� ������ ��� ī�� ��� ����
        }

        player.CurrentEnergy -= cardData.cost; // ������ ����

        // ī�� Ÿ�Կ� ���� ���� ó��
        switch (cardData.cardType)
        {
            case CardType.Attack:
                Debug.Log($"{cardData.cardName}�� ���ظ� �ݴϴ�!");
                break;
            case CardType.Defense:
                Debug.Log($"{cardData.cardName}�� ���ظ� �����ϴ�!");
                break;
            case CardType.Resource:
                Debug.Log($"{cardData.cardName}�� �ڿ��� �����մϴ�!");
                break;
        }

        return true; // ī�� ��� ����
    }

    public void ChangeState(ECardUsage cardUsage)
    {
        _baseCardStateFactory.ChangeState(cardUsage);
    }

    public void UseCard()
    {
        if(Player.instance.PlayerState.CurrentOrb >= cardData.cost)
        {
            Player.instance.PlayerState.CurrentOrb -= cardData.cost;
            cardData.useEffect.ForEach(useEffect => useEffect?.Invoke());
            CardHolder.instance.DiscardCard(this);
            //Destroy(gameObject);
        }
    }

    public void SetMyButtonAction(Action action)
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() => action());
    }
}