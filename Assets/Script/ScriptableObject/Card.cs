using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;
    public void Initialize(CardData data)
    {
        cardData = data;
    }

    public bool Play(Deck deck, Player player)
    {
        if (player.CurrentEnergy < cardData.cost)
        {
            Debug.Log($"�ڽ�Ʈ�� �����մϴ�. �ʿ� �ڽ�Ʈ: {cardData.cost}, ���� ������: {player.CurrentEnergy}");
            return false; // �������� ������ ��� ī�� ��� ����
        }

        player.CurrentEnergy -= cardData.cost; // ������ ����

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

        deck.ReturnCardToDeck(cardData); // ī�� ��� �� ������ ���ư���
        Destroy(gameObject); // ī�� ������Ʈ ����
        return true; // ī�� ��� ����
    }
}