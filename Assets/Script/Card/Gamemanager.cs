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
        //cardGenerator.AllCardList = new List<CardData>();

        // 카드 데이터를 리스트에 추가
       // cardGenerator.AllCardList.Add(warriorCard);

        Player.instance.CardGenerator = cardGenerator;
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();
        Player.instance.GenerateRandomCard();

        //CardHolder.instance.StartBattle(Player.instance.PlayerDeck);

        UIManager.instance.SetMapUI(true);
    }
}