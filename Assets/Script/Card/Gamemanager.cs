using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardGenerator cardGenerator;

    void Start()
    {
        // 게임 시작 시 카드 생성
        for (int i = 0; i < 10; i++) // 예시로 10장의 카드를 생성
        {
            cardGenerator.GenerateRandomCard();
        }
    }
}