using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;

public enum ECardUsage
{
    Battle,   // 배틀
    Check,    // 확인
    Gain,     // 얻기
    Enforce,  // 강화
    DisCard,  // 제거
    Sell,     // 판매
}

public class BaseCard : MonoBehaviour
{
    [SerializeField]
    private CardController _cardController;

    public CardData cardData; // 카드 데이터
    public Action onClickAction;

    private BaseCardStateFactory _baseCardStateFactory;

    public BaseCardState CurrentState => _baseCardStateFactory.CurrentState;
    public CardController CardController => _cardController;

    public void Init(Transform cardHolder, CardData data)
    {
        cardData = data;
        transform.SetParent(cardHolder);
        _baseCardStateFactory = new BaseCardStateFactory(this);

        _cardController.Init(this);
        // 카드 이미지와 설명을 설정하는 로직을 추가할 수 있습니다.
    }

    public bool Play(Player player)
    {
        if (player.CurrentEnergy < cardData.cost)
        {
            Debug.Log($"코스트가 부족합니다. 필요 코스트: {cardData.cost}, 현재 에너지: {player.CurrentEnergy}");
            return false; // 에너지가 부족할 경우 카드 사용 실패
        }

        player.CurrentEnergy -= cardData.cost; // 에너지 차감

        // 카드 타입에 따른 로직 처리
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

        return true; // 카드 사용 성공
    }

    public void ChangeState(ECardUsage cardUsage)
    {
        _baseCardStateFactory.ChangeState(cardUsage);
    }

    public void UseCard()
    {
        if(Player.instance.PlayerState.CurrentOrb >= cardData.cost)
        {
            Player.instance.PlayerState.CurrentOrb -= cardData.cost;
            cardData.useEffect.ForEach(useEffect => useEffect?.Invoke());
            CardHolder.instance.DiscardCard(this);
            //Destroy(gameObject);
        }
    }

    public void SetMyButtonAction(Action action)
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() => action());
    }
}