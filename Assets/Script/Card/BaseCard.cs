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
        if (player.CurrentEnergy < CardData.Cost)
        {
            Debug.Log($"�ڽ�Ʈ�� �����մϴ�. �ʿ� �ڽ�Ʈ: {CardData.Cost}, ���� ������: {player.CurrentEnergy}");
            return false; // �������� ������ ��� ī�� ��� ����
        }

        player.CurrentEnergy -= CardData.Cost; // ������ ����

        // ī�� Ÿ�Կ� ���� ���� ó��
        switch (CardData.CardType)
        {
            case CardType.Attack:
                Debug.Log($"{CardData.CardName}�� ���ظ� �ݴϴ�!");
                break;
            case CardType.Defense:
                Debug.Log($"{CardData.CardName}�� ���ظ� �����ϴ�!");
                break;
            case CardType.Resource:
                Debug.Log($"{CardData.CardName}�� �ڿ��� �����մϴ�!");
                break;
        }

        return true; // ī�� ��� ����
    }
}