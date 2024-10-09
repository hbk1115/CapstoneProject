using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;
    public int CurrentEnergy { get; set; } = 10; // 기본 에너지
    public CardGenerator CardGenerator; // CardGenerator 인스턴스
    public List<BaseCard> PlayerDeck = new List<BaseCard>(); // 플레이어의 카드 덱

    void Awake()
    {
        instance = this;
        ShowPlayerDeck(); // 현재 플레이어 덱 표시
    }

    // 카드 생성 메서드
    public void GenerateCard(string cardName)
    {
        Debug.Log($"카드 생성 시도: {cardName}");

        if (CardGenerator == null)
        {
            Debug.LogError("CardGenerator가 null입니다. 확인해 주세요."); // CardGenerator null 체크
            return; // CardGenerator가 null일 경우 메서드 종료
        }

        if (CurrentEnergy > 0)
        {
            BaseCard generatedCard = CardGenerator.GenerateCard(cardName);

            if (generatedCard == null || generatedCard.CardData == null) // null 체크 추가
            {
                Debug.LogError("generatedCard 또는 CardData가 null입니다. 카드 생성이 실패했습니다."); // 추가 로그
                return; // 생성된 카드가 null일 경우 메서드 종료
            }

            Debug.Log($"{generatedCard.CardData.CardName} 카드가 생성되었습니다.");
            PlayerDeck.Add(generatedCard); // 플레이어의 덱에 추가
            CurrentEnergy--; // 카드를 생성하면 에너지 감소
        }
        else
        {
            Debug.LogWarning("에너지가 부족하여 카드를 생성할 수 없습니다.");
        }
    }

    // 랜덤 카드 생성 메서드
    public void GenerateRandomCard()
    {
        if (CardGenerator.AllCardList == null || CardGenerator.AllCardList.Count == 0)
        {
            Debug.LogError("카드 리스트가 비어있어 랜덤 카드를 생성할 수 없습니다.");
            return; // 카드 리스트가 비어있으면 메서드 종료
        }

        int randomIndex = Random.Range(0, CardGenerator.AllCardList.Count); // 랜덤 인덱스 생성
        CardData randomCardData = CardGenerator.AllCardList[randomIndex]; // 랜덤 카드 데이터 선택
        GenerateCard(randomCardData.CardName); // 선택한 카드 데이터로 카드 생성
    }

    // 카드 목록 확인
    public void ShowPlayerDeck()
    {
        Debug.Log("플레이어 덱:");
        foreach (var card in PlayerDeck)
        {
            Debug.Log($"- {card}");
        }
    }
}