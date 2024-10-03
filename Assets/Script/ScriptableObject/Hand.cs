using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<Card> playerHand = new List<Card>();
    public Transform handContainer; // Unity 에디터에서 할당

    public void AddCard(Card card)
    {
        playerHand.Add(card);
        card.transform.SetParent(handContainer);
        // 카드의 위치 조정 등
    }

    public void PlayCard(Card card, Deck deck, Player player)
    {
        if (playerHand.Remove(card))
        {
            card.Play(deck, player); // 덱과 플레이어를 넘겨서 카드 사용 처리
        }
    }
}