using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    [Header("카드 이미지")]
    [SerializeField] private Image mainImage;
    [SerializeField] private Image angleImage;
    [SerializeField] private Image attackAreaImage;
    [SerializeField] private Image cardTypeImage;

    [SerializeField] private TextMeshProUGUI cost_Text;
    [SerializeField] private TextMeshProUGUI name_Text;
    [SerializeField] private TextMeshProUGUI cardType_Text;

    public void Init(Transform cardHolder, CardData data)
    {
        cardData = data;
        transform.SetParent(cardHolder);
        _baseCardStateFactory = new BaseCardStateFactory(this);

        _cardController.Init(this);
        // 카드 이미지와 설명을 설정하는 로직을 추가할 수 있습니다.
        mainImage.sprite = cardData.cardImage;
        angleImage.sprite = CardGenerator.instance.elementTypeSprite[(int)cardData.cardElement];
        attackAreaImage.sprite = CardGenerator.instance.attackAreaTypeSprite[(int)cardData.cardAttackArea];
        cardTypeImage.sprite = CardGenerator.instance.attackTypeSprite[(int)cardData.cardType];

        cost_Text.text = cardData.cost.ToString();
        name_Text.text = cardData.cardName.ToString();

        if(cardData.cardType == CardType.Attack)
        {
            cardType_Text.text = cardData.attackPower.ToString();
        }
        else if (cardData.cardType == CardType.Defense)
        {
            cardType_Text.text = cardData.defensePower.ToString();
        }
        else
        {
            cardType_Text.text = cardData.resourcePower.ToString();
        }
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
            //SpawnEffect();
            //SpawnDamageText();
            //AudioManager.instance.PlaySfx(AudioManager.Sfx.select_card);

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

    public void CardDisappear()
    {
        this.transform.localScale = Vector3.zero;
    }

    public void SpawnEffect()
    {
        if(cardData.cardAttackArea == CardAttackArea.All)
        {
            for(int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
            {
                GameObject newEffect = EffectManager.instance.GetEffect(cardData);
                newEffect.transform.position = BattleManager.instance.enemyList[i].transform.position;
            }
        }
        else if(cardData.cardAttackArea == CardAttackArea.Player)
        {
            GameObject newEffect = EffectManager.instance.GetEffect(cardData);
            newEffect.transform.position = Player.instance.transform.position;
        }
        else
        {
            GameObject newEffect = EffectManager.instance.GetEffect(cardData);
            newEffect.transform.position = BattleManager.instance.TargetEnemy(cardData.cardAttackArea).transform.position;
        }
    }

    /*
    
    */
}