using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int CurrentEnergy { get; set; } = 3; // �⺻ ������
    public CardGenerator CardGenerator; // CardGenerator �ν��Ͻ�
    private List<CardData> PlayerDeck = new List<CardData>(); // �÷��̾��� ī�� ��

    void Start()
    {
        // ī�� ���� ����: "Warrior" ī�� ����
        GenerateCard("Warrior");
        ShowPlayerDeck(); // ���� �÷��̾� �� ǥ��
    }

    // ī�� ���� �޼���
    public void GenerateCard(string cardName)
    {
        Debug.Log($"ī�� ���� �õ�: {cardName}");

        if (CardGenerator == null)
        {
            Debug.LogError("CardGenerator�� null�Դϴ�. Ȯ���� �ּ���."); // CardGenerator null üũ
            return; // CardGenerator�� null�� ��� �޼��� ����
        }

        if (CurrentEnergy > 0)
        {
            BaseCard generatedCard = CardGenerator.GenerateCard(cardName);

            if (generatedCard == null || generatedCard.CardData == null) // null üũ �߰�
            {
                Debug.LogError("generatedCard �Ǵ� CardData�� null�Դϴ�. ī�� ������ �����߽��ϴ�."); // �߰� �α�
                return; // ������ ī�尡 null�� ��� �޼��� ����
            }

            Debug.Log($"{generatedCard.CardData.CardName} ī�尡 �����Ǿ����ϴ�.");
            PlayerDeck.Add(generatedCard.CardData); // �÷��̾��� ���� �߰�
            CurrentEnergy--; // ī�带 �����ϸ� ������ ����
        }
        else
        {
            Debug.LogWarning("�������� �����Ͽ� ī�带 ������ �� �����ϴ�.");
        }
    }

    // ���� ī�� ���� �޼���
    public void GenerateRandomCard()
    {
        if (CardGenerator.AllCardList == null || CardGenerator.AllCardList.Count == 0)
        {
            Debug.LogError("ī�� ����Ʈ�� ����־� ���� ī�带 ������ �� �����ϴ�.");
            return; // ī�� ����Ʈ�� ��������� �޼��� ����
        }

        int randomIndex = Random.Range(0, CardGenerator.AllCardList.Count); // ���� �ε��� ����
        CardData randomCardData = CardGenerator.AllCardList[randomIndex]; // ���� ī�� ������ ����
        GenerateCard(randomCardData.CardName); // ������ ī�� �����ͷ� ī�� ����
    }

    // ī�� ��� Ȯ��
    public void ShowPlayerDeck()
    {
        Debug.Log("�÷��̾� ��:");
        foreach (var card in PlayerDeck)
        {
            Debug.Log($"- {card.CardName}");
        }
    }
}