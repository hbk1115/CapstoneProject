using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Deck playerDeck;
    public Hand playerHand;
    public Player player;

    // ���� ī�� ������ ����
    public List<CardData> allCards; // Unity �����Ϳ��� �Ҵ�

    void Start()
    {
        playerDeck.InitializeDeck(allCards);

        for (int i = 0; i < 5; i++)
        {
            CardData drawnCard = playerDeck.DrawCard();
            if (drawnCard != null)
            {
                Card card = InstantiateCard(drawnCard);
                playerHand.AddCard(card);
            }
        }
    }

    private Card InstantiateCard(CardData data)
    {
        GameObject cardObject = new GameObject(data.cardName);
        Card card = cardObject.AddComponent<Card>();
        card.Initialize(data);
        return card;
    }

    public void OnPlayCard(Card card)
    {
        playerHand.PlayCard(card, playerDeck, player); // �÷��̾�� ���� �Ѱܼ� ī�� ���
    }
}