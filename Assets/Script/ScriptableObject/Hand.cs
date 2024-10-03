using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<Card> playerHand = new List<Card>();
    public Transform handContainer; // Unity �����Ϳ��� �Ҵ�

    public void AddCard(Card card)
    {
        playerHand.Add(card);
        card.transform.SetParent(handContainer);
        // ī���� ��ġ ���� ��
    }

    public void PlayCard(Card card, Deck deck, Player player)
    {
        if (playerHand.Remove(card))
        {
            card.Play(deck, player); // ���� �÷��̾ �Ѱܼ� ī�� ��� ó��
        }
    }
}