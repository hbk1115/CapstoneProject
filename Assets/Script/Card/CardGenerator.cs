using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public BaseCard BaseCardPrefab; // ī�� ������
    public Transform CardParent; // ī�尡 ������ �θ� ������Ʈ
    public List<CardData> AllCardList; // ī�� ������ ����Ʈ
    private int GenerateNumber = 1; // ī�� ���� ID ī����

    // ī�� �̸����� ī�� ����
    public BaseCard GenerateCard(string cardName)
    {
        Debug.Log($"Searching for card: {cardName}");
        CardData cardData = AllCardList.Find(card => card.CardName == cardName);

        if (cardData == null)
        {
            Debug.LogError($"{cardName} ī�尡 ���� �������� �ʽ��ϴ�.");
            return null; // ī�尡 ���� ��� null ��ȯ
        }

        return CreateCardFromData(cardData);
    }

    // ī�� �����͸� ������� ī�� ����
    private BaseCard CreateCardFromData(CardData cardData)
    {
        if (cardData == null)
        {
            Debug.LogError("ī�� �����Ͱ� null�Դϴ�.");
            return null;
        }

        if (BaseCardPrefab == null)
        {
            Debug.LogError("BaseCardPrefab�� null�Դϴ�. �������� �Ҵ��ϼ���.");
            return null;
        }

        BaseCard baseCard = Instantiate(BaseCardPrefab, CardParent);
        cardData.AssignId(GenerateNumber); // ī�� �����Ϳ� ID�� �Ҵ�
        baseCard.name = $"player.{cardData.CardName}"; // ī���� �̸��� "player."�� �����ϰ� ����
        GenerateNumber++; // ���� ī�� ���� �� ID ����

        baseCard.CardData = cardData; // ������ ī�忡 ī�� �����͸� �Ҵ�
        return baseCard;
    }
}