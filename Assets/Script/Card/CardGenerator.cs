using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public BaseCard baseCardPrefab; // ī�� ������
    public Transform cardParent; // ī�尡 ������ �θ� ������Ʈ
    public List<CardData> allCardList; // ī�� ������ ����Ʈ
    private int generateNumber = 1; // ī�� ���� ID ī����
    private int currentCardCount = 0; // ���� ������ ī�� ��
    private const int maxCardCount = 20; // �ִ� ī�� ��

    void Start()
    {
        // ���÷� "Warrior"��� �̸��� ī�� ����
        GenerateCard("Warrior");
    }

    // ���� ī�� ���� �޼���
    public BaseCard GenerateRandomCard()
    {
        if (allCardList.Count == 0)
        {
            Debug.LogError("ī�� ������ ����Ʈ�� ��� �ֽ��ϴ�.");
            return null;
        }

        if (currentCardCount >= maxCardCount)
        {
            Debug.LogWarning("�ִ� ī�� ���� �����߽��ϴ�.");
            return null;
        }

        int randomIndex = Random.Range(0, allCardList.Count);
        CardData cardData = allCardList[randomIndex];
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

        if (baseCardPrefab == null)
        {
            Debug.LogError("baseCardPrefab�� null�Դϴ�. �������� �Ҵ��ϼ���.");
            return null;
        }

        BaseCard baseCard = Instantiate(baseCardPrefab, cardParent);
        cardData.AssignId(generateNumber); // ī�� �����Ϳ� ID�� �Ҵ�

        // ID ���� �� �α� ���
        Debug.Log($"ī�� ID�� {generateNumber}�� �����Ǿ����ϴ�: {cardData.cardName}");

        baseCard.Init(cardParent, cardData); // ī�� ������ �ʱ�ȭ
        generateNumber++; // ���� ī�� ���� �� ID ����
        currentCardCount++; // ���� ī�� �� ����

        return baseCard;
    }

    // ī�� ������ ��ȯ
    public void ReturnCardToDeck(CardData cardData)
    {
        if (cardData != null)
        {
            allCardList.Add(cardData); // ������ ����
            Debug.Log($"{cardData.cardName}�� ������ ���ư����ϴ�.");
        }
    }

    // ī�� ��� �޼���
    public BaseCard PlayCard(BaseCard cardToPlay, Player player)
    {
        if (cardToPlay.Play(player)) // ī�� ��� ���� ��
        {
            ReturnCardToDeck(cardToPlay.cardData); // ���� ī�� ������ ��ȯ
            currentCardCount--; // ���� ī�� �� ����
            return cardToPlay;
        }
        return null; // ī�� ��� ����
    }

    // ī�� �̸����� ī�� ����
    public BaseCard GenerateCard(string cardName)
    {
        Debug.Log($"Searching for card: {cardName}");
        CardData cardData = allCardList.Find(card => card.cardName == cardName);

        if (cardData == null)
        {
            Debug.LogError($"{cardName} ī�尡 ���� �������� �ʽ��ϴ�.");
            return null; // ī�尡 ���� ��� null ��ȯ
        }

        return CreateCardFromData(cardData);
    }
}