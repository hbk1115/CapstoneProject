using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ECardUsage
{
    Battle,   // ��Ʋ
    Check,    // Ȯ��
    Gain,     // ���
    Enforce,  // ��ȭ
    DisCard,  // ����
    Sell,     // �Ǹ�
}

public class BaseCard : MonoBehaviour
{
    [SerializeField]
    private CardController _cardController;

    public CardData cardData; // ī�� ������
    public Action onClickAction;

    private BaseCardStateFactory _baseCardStateFactory;

    public BaseCardState CurrentState => _baseCardStateFactory.CurrentState;
    public CardController CardController => _cardController;

    [Header("ī�� �̹���")]
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
        // ī�� �̹����� ������ �����ϴ� ������ �߰��� �� �ֽ��ϴ�.
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
            Debug.Log($"�ڽ�Ʈ�� �����մϴ�. �ʿ� �ڽ�Ʈ: {cardData.cost}, ���� ������: {player.CurrentEnergy}");
            return false; // �������� ������ ��� ī�� ��� ����
        }

        player.CurrentEnergy -= cardData.cost; // ������ ����

        // ī�� Ÿ�Կ� ���� ���� ó��
        switch (cardData.cardType)
        {
            case CardType.Attack:
                Debug.Log($"{cardData.cardName}�� ���ظ� �ݴϴ�!");
                break;
            case CardType.Defense:
                Debug.Log($"{cardData.cardName}�� ���ظ� �����ϴ�!");
                break;
            case CardType.Resource:
                Debug.Log($"{cardData.cardName}�� �ڿ��� �����մϴ�!");
                break;
        }

        return true; // ī�� ��� ����
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