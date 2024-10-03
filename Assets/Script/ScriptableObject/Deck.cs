using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<CardData> deckCards = new List<CardData>();
    private List<CardData> drawnCards = new List<CardData>();
    private const int MAX_DECK_SIZE = 20;

    public void InitializeDeck(List<CardData> cards)
    {
        // ī�� ���� �ִ� 20������ ����
        if (cards.Count > MAX_DECK_SIZE)
        {
            cards = cards.GetRange(0, MAX_DECK_SIZE);
        }

        // �����ϰ� 10�� �̱�
        for (int i = 0; i < 10 && cards.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, cards.Count);
            deckCards.Add(cards[randomIndex]);
            cards.RemoveAt(randomIndex);
        }

        ShuffleDeck();
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < deckCards.Count; i++)
        {
            CardData temp = deckCards[i];
            int randomIndex = Random.Range(i, deckCards.Count);
            deckCards[i] = deckCards[randomIndex];
            deckCards[randomIndex] = temp;
        }
    }

    public CardData DrawCard()
    {
        if (deckCards.Count == 0)
        {
            Debug.Log("���� ī�尡 �����ϴ�!");
            return null;
        }

        CardData drawnCard = deckCards[0];
        deckCards.RemoveAt(0);
        drawnCards.Add(drawnCard);
        return drawnCard;
    }

    public void ReturnCardToDeck(CardData card)
    {
        if (card != null)
        {
            deckCards.Add(card);
            ShuffleDeck(); // ī�尡 �߰��� �� ���� �����ϴ�.
            Debug.Log($"{card.cardName}�� ������ ���ư����ϴ�.");
        }
    }
}