using UnityEngine;

public class BaseCard : MonoBehaviour
{
    public CardData CardData; // ī�� ������

    public void Init(Transform cardHolder, CardData data)
    {
        CardData = data;
        // ī�� �̹����� ������ �����ϴ� ������ �߰��� �� �ֽ��ϴ�.
    }

    public bool Play(Player player)
    {
        if (player.CurrentEnergy < CardData.cost)
        {
            Debug.Log($"�ڽ�Ʈ�� �����մϴ�. �ʿ� �ڽ�Ʈ: {CardData.cost}, ���� ������: {player.CurrentEnergy}");
            return false; // �������� ������ ��� ī�� ��� ����
        }

        player.CurrentEnergy -= CardData.cost; // ������ ����

        // ī�� Ÿ�Կ� ���� ���� ó��
        switch (CardData.cardType)
        {
            case CardType.Attack:
                Debug.Log($"{CardData.cardName}�� ���ظ� �ݴϴ�!");
                break;
            case CardType.Defense:
                Debug.Log($"{CardData.cardName}�� ���ظ� �����ϴ�!");
                break;
            case CardType.Resource:
                Debug.Log($"{CardData.cardName}�� �ڿ��� �����մϴ�!");
                break;
        }

        return true; // ī�� ��� ����
    }
}