using UnityEngine;

public class BaseCard : MonoBehaviour
{
    public CardData CardData; // 카드 데이터

    public void Init(Transform cardHolder, CardData data)
    {
        CardData = data;
        // 카드 이미지와 설명을 설정하는 로직을 추가할 수 있습니다.
    }

    public bool Play(Player player)
    {
        if (player.CurrentEnergy < CardData.Cost)
        {
            Debug.Log($"코스트가 부족합니다. 필요 코스트: {CardData.Cost}, 현재 에너지: {player.CurrentEnergy}");
            return false; // 에너지가 부족할 경우 카드 사용 실패
        }

        player.CurrentEnergy -= CardData.Cost; // 에너지 차감

        // 카드 타입에 따른 로직 처리
        switch (CardData.CardType)
        {
            case CardType.Attack:
                Debug.Log($"{CardData.CardName}가 피해를 줍니다!");
                break;
            case CardType.Defense:
                Debug.Log($"{CardData.CardName}가 피해를 막습니다!");
                break;
            case CardType.Resource:
                Debug.Log($"{CardData.CardName}가 자원을 생성합니다!");
                break;
        }

        return true; // 카드 사용 성공
    }
}