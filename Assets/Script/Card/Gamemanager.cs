using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardGenerator cardGenerator; // 카드 생성기 인스턴스

    void Start()
    {
        if (cardGenerator == null)
        {
            Debug.LogError("CardGenerator가 할당되지 않았습니다!");
            return; // 오류 메시지 출력 후 메서드 종료
        }

        // 카드 데이터 리스트 초기화
        cardGenerator.AllCardList = new List<CardData>();

        // "Warrior" 카드 데이터 생성
        CardData warriorCard = ScriptableObject.CreateInstance<CardData>();
        warriorCard.CardName = "Warrior";
        warriorCard.CardType = CardType.Attack;
        warriorCard.Cost = 1;
        warriorCard.CardDescription = "A fierce warrior card.";
        warriorCard.CardElement = CardElement.Fire;

        // 카드 데이터를 리스트에 추가
        cardGenerator.AllCardList.Add(warriorCard);
        Debug.Log("Warrior 카드 데이터가 성공적으로 생성되었습니다."); // 카드 데이터 생성 확인

        Player.instance.CardGenerator = cardGenerator;
        Player.instance.GenerateCard("Warrior");
        Player.instance.GenerateCard("Warrior");
        Player.instance.GenerateCard("Warrior");
        Player.instance.GenerateCard("Warrior");
        Player.instance.GenerateCard("Warrior");
        Player.instance.GenerateCard("Warrior");

        // 플레이어 생성 및 초기화
        //Player player = gameObject.AddComponent<Player>();
        //player.CardGenerator = cardGenerator; // CardGenerator 연결

        // 카드 생성 예시: 랜덤 카드 생성
        //player.GenerateRandomCard(); // 예시 랜덤 카드 생성
    }
}