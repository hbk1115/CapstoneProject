using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<CardData> deckCards = new List<CardData>();
    private List<CardData> drawnCards = new List<CardData>();
    private const int MAX_DECK_SIZE = 20;

    public void InitializeDeck(List<CardData> cards)
    {
        // 카드 수를 최대 20장으로 제한
        if (cards.Count > MAX_DECK_SIZE)
        {
            cards = cards.GetRange(0, MAX_DECK_SIZE);
        }

        // 랜덤하게 10장 뽑기
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
            Debug.Log("덱에 카드가 없습니다!");
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
            ShuffleDeck(); // 카드가 추가된 후 덱을 섞습니다.
            Debug.Log($"{card.cardName}가 덱으로 돌아갔습니다.");
        }
    }
}