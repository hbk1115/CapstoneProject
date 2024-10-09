using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public BaseCard BaseCardPrefab; // 카드 프리팹
    public Transform CardParent; // 카드가 생성될 부모 오브젝트
    public List<CardData> AllCardList; // 카드 데이터 리스트
    private int GenerateNumber = 1; // 카드 생성 ID 카운터

    // 카드 이름으로 카드 생성
    public BaseCard GenerateCard(string cardName)
    {
        Debug.Log($"Searching for card: {cardName}");
        CardData cardData = AllCardList.Find(card => card.CardName == cardName);

        if (cardData == null)
        {
            Debug.LogError($"{cardName} 카드가 덱에 존재하지 않습니다.");
            return null; // 카드가 없을 경우 null 반환
        }

        return CreateCardFromData(cardData);
    }

    // 카드 데이터를 기반으로 카드 생성
    private BaseCard CreateCardFromData(CardData cardData)
    {
        if (cardData == null)
        {
            Debug.LogError("카드 데이터가 null입니다.");
            return null;
        }

        if (BaseCardPrefab == null)
        {
            Debug.LogError("BaseCardPrefab이 null입니다. 프리팹을 할당하세요.");
            return null;
        }

        BaseCard baseCard = Instantiate(BaseCardPrefab, CardParent);
        cardData.AssignId(GenerateNumber); // 카드 데이터에 ID를 할당
        baseCard.name = $"player.{cardData.CardName}"; // 카드의 이름을 "player."로 시작하게 설정
        GenerateNumber++; // 다음 카드 생성 시 ID 증가

        baseCard.CardData = cardData; // 생성한 카드에 카드 데이터를 할당
        return baseCard;
    }
}