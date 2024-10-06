using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public BaseCard baseCardPrefab; // 카드 프리팹
    public Transform cardParent; // 카드가 생성될 부모 오브젝트
    public List<CardData> allCardList; // 카드 데이터 리스트
    private int generateNumber = 1; // 카드 생성 ID 카운터
    private int currentCardCount = 0; // 현재 생성된 카드 수
    private const int maxCardCount = 20; // 최대 카드 수

    void Start()
    {
        // 예시로 "Warrior"라는 이름의 카드 생성
        GenerateCard("Warrior");
    }

    // 랜덤 카드 생성 메서드
    public BaseCard GenerateRandomCard()
    {
        if (allCardList.Count == 0)
        {
            Debug.LogError("카드 데이터 리스트가 비어 있습니다.");
            return null;
        }

        if (currentCardCount >= maxCardCount)
        {
            Debug.LogWarning("최대 카드 수에 도달했습니다.");
            return null;
        }

        int randomIndex = Random.Range(0, allCardList.Count);
        CardData cardData = allCardList[randomIndex];
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

        if (baseCardPrefab == null)
        {
            Debug.LogError("baseCardPrefab이 null입니다. 프리팹을 할당하세요.");
            return null;
        }

        BaseCard baseCard = Instantiate(baseCardPrefab, cardParent);
        cardData.AssignId(generateNumber); // 카드 데이터에 ID를 할당

        // ID 증가 후 로그 출력
        Debug.Log($"카드 ID가 {generateNumber}로 설정되었습니다: {cardData.cardName}");

        baseCard.Init(cardParent, cardData); // 카드 데이터 초기화
        generateNumber++; // 다음 카드 생성 시 ID 증가
        currentCardCount++; // 현재 카드 수 증가

        return baseCard;
    }

    // 카드 덱으로 반환
    public void ReturnCardToDeck(CardData cardData)
    {
        if (cardData != null)
        {
            allCardList.Add(cardData); // 덱으로 복귀
            Debug.Log($"{cardData.cardName}가 덱으로 돌아갔습니다.");
        }
    }

    // 카드 사용 메서드
    public BaseCard PlayCard(BaseCard cardToPlay, Player player)
    {
        if (cardToPlay.Play(player)) // 카드 사용 성공 시
        {
            ReturnCardToDeck(cardToPlay.cardData); // 사용된 카드 덱으로 반환
            currentCardCount--; // 현재 카드 수 감소
            return cardToPlay;
        }
        return null; // 카드 사용 실패
    }

    // 카드 이름으로 카드 생성
    public BaseCard GenerateCard(string cardName)
    {
        Debug.Log($"Searching for card: {cardName}");
        CardData cardData = allCardList.Find(card => card.cardName == cardName);

        if (cardData == null)
        {
            Debug.LogError($"{cardName} 카드가 덱에 존재하지 않습니다.");
            return null; // 카드가 없을 경우 null 반환
        }

        return CreateCardFromData(cardData);
    }
}