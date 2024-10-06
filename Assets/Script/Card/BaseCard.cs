using UnityEngine;

public class BaseCard : MonoBehaviour
{
    public CardData cardData;

    public void Init(Transform cardHolder, CardData data)
    {
        cardData = data;
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
}