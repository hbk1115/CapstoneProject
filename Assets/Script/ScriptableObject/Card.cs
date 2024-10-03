using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;
    public void Initialize(CardData data)
    {
        cardData = data;
    }

    public bool Play(Deck deck, Player player)
    {
        if (player.CurrentEnergy < cardData.cost)
        {
            Debug.Log($"코스트가 부족합니다. 필요 코스트: {cardData.cost}, 현재 에너지: {player.CurrentEnergy}");
            return false; // 에너지가 부족할 경우 카드 사용 실패
        }

        player.CurrentEnergy -= cardData.cost; // 에너지 차감

        switch (cardData.cardType)
        {
            case CardType.Attack:
                Debug.Log($"{cardData.cardName}가 피해를 줍니다!");
                break;
            case CardType.Defense:
                Debug.Log($"{cardData.cardName}가 피해를 막습니다!");
                break;
            case CardType.Resource:
                Debug.Log($"{cardData.cardName}가 자원을 생성합니다!");
                break;
        }

        deck.ReturnCardToDeck(cardData); // 카드 사용 후 덱으로 돌아가기
        Destroy(gameObject); // 카드 오브젝트 제거
        return true; // 카드 사용 성공
    }
}