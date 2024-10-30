using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using UnityEngine.UIElements;

public class CardHolder : MonoBehaviour
{
    static public CardHolder instance;

    private bool isBattle = false;
    [SerializeField]
    private Transform _cardTransform;

    [SerializeField]
    private Transform _cardDeckTransform; // 카드 덱 위치
    [SerializeField]
    private Transform _cardCemetryTransform; // 카드 묘지 위치
    [SerializeField]
    private Transform _cardExtinctionTransform; // 카드 소멸 위치

    [SerializeField]
    private TextMeshProUGUI _cardDeckCountText;
    [SerializeField]
    private TextMeshProUGUI _cardCemetryCountText;
    [SerializeField]
    private TextMeshProUGUI _cardExtinctionCountText;

    [SerializeField]
    private MyList<BaseCard> _cardDeck;  // 카드 덱
    [SerializeField]
    private MyList<BaseCard> _cardHands; // 카드 패
    [SerializeField]
    private MyList<BaseCard> _cardCemetry; // 카드 묘지
    [SerializeField]
    private MyList<BaseCard> _cardExtinction; // 카드 소멸

    private List<BaseCard> _temporaryList = new List<BaseCard>();

    //카드 뽑고, 다음 턴 넘길 때, 카드 다 버리고 다시 뽑기 만들기
    //적 턴 넘어가는거 다시 할당해서 조절하기(공격 등 BattleManagerStateFactory에서 관리)
    //그 이외의 카드의 움직임들 모두 cardHolder에서 관리하도록 변경

    private void Awake()
    {
        instance = this;
    }

    public void StartBattle(List<BaseCard> myCard)
    {
        isBattle = true;

        // 필요없는 카드는 제거
        while (_temporaryList.Count != 0)
        {
            BaseCard card = _temporaryList[0];
            _temporaryList.Remove(card);
            Destroy(card.gameObject);
        }

        _cardExtinctionTransform.gameObject.SetActive(false);

        _cardDeck = new MyList<BaseCard>();
        _cardHands = new MyList<BaseCard>();
        _cardCemetry = new MyList<BaseCard>();
        _cardExtinction = new MyList<BaseCard>();

        _cardDeck.onChangeList = null;
        _cardHands.onChangeList = null;
        _cardCemetry.onChangeList = null;
        _cardExtinction.onChangeList = null;

        _cardDeck.onChangeList += ShowCardCount;
        _cardHands.onChangeList += ShowCardCount;
        _cardCemetry.onChangeList += ShowCardCount;
        _cardExtinction.onChangeList += ShowCardCount;

        _temporaryList = new List<BaseCard>();

        // 내 카드 넣기
        foreach (BaseCard card in myCard)
        {
            // 위치 초기화
            card.transform.SetParent(_cardTransform);

            card.ChangeState(ECardUsage.Battle);

            card.transform.localPosition = _cardDeckTransform.localPosition;
            card.transform.localEulerAngles = Vector3.zero;
            card.transform.localScale = Vector3.zero;

            _cardDeck.Add(card);
        }

        // 셔플
        Util.ShuffleList(_cardDeck);
    }

    private void ShowCardCount()
    {
        _cardDeckCountText.text = _cardDeck.Count.ToString();
        _cardCemetryCountText.text = _cardCemetry.Count.ToString();
        _cardExtinctionCountText.text = _cardExtinction.Count.ToString();
    }

    public void EndBattle(List<BaseCard> myCard)
    {
        DiscardAllCard();
        isBattle = false;
        _cardExtinctionTransform.gameObject.SetActive(false);
    }


    // 소멸
    public void Extinction(BaseCard card)
    {
        _cardHands.Remove(card);
        _cardExtinction.Add(card);

        Relocation();

        // 소멸된 카드가 1장이라도 있으면 소멸 UI 생성
        if (_cardExtinction.Count > 0)
        {
            _cardExtinctionTransform.gameObject.SetActive(true);
        }
        else
        {
            _cardExtinctionTransform.gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// 카드 드로우
    /// </summary>
    public void DrawCard()
    {
        // 패에 카드 10장이상이면 더이상 카드를 드로우하지 못함
        if (_cardHands.Count >= 10)
        {
            return;
        }

        // 뽑을 카드가 없으면 묘지에 있는 카드를 전부 덱에 넣고 셔플한 다음 드로우
        if (_cardDeck.Count <= 0)
        {
            ReturnToDeck();
            Util.ShuffleList(_cardDeck);
        }

        // 덱에 한 장 뽑아서 패에 넣음
        BaseCard card = _cardDeck[_cardDeck.Count - 1];
        _cardHands.Add(card);
        _cardDeck.Remove(card);

        Relocation();
    }

    public void DiscardCard(BaseCard card)
    {
        _cardCemetry.Add(card);
        _cardHands.Remove(card);

        Relocation();

        card.transform.localEulerAngles = Vector3.zero;
        card.transform.localScale = Vector3.zero;
    }
    // 해당 카드가 패에 몇번째있는지 반환
    private int GetCardIndex(BaseCard card)
    {
        for (int i = 0; i < _cardHands.Count; i++)
        {
            if (card == _cardHands[i])
            {
                return i;
            }
        }
        return -1;
    }

    // 묘지 카드 전부 덱으로 귀환
    private void ReturnToDeck()
    {
        while (_cardCemetry.Count != 0)
        {
            BaseCard card = _cardCemetry[_cardCemetry.Count - 1];
            _cardDeck.Add(card);
            _cardCemetry.Remove(card);

            card.transform.localPosition = _cardDeckTransform.localPosition;
        }
    }

    // 패에 있는 모든 카드 버리기
    public void DiscardAllCard()
    {
        while (_cardHands.Count != 0)
        {
            BaseCard card = _cardHands[_cardHands.Count - 1];
            DiscardCard(card);
        }
    }
    public void Relocation()
    {
        // 카드 간격 설정
        float spacing = 150f;

        // 중앙 정렬을 위한 시작 위치 계산
        float totalWidth = (_cardHands.Count - 1) * spacing; // 전체 너비 계산
        float startX = -totalWidth / 2; // 시작 위치 (중앙 정렬을 위해)

        for (int i = 0; i < _cardHands.Count; i++)
        {
            _cardHands[i].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);//앵커 중앙으로 고정
            _cardHands[i].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            _cardHands[i].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            _cardHands[i].transform.localEulerAngles = Vector3.zero; // 회전 초기화
            _cardHands[i].transform.localScale = Vector3.one; // 스케일 초기화

            // 카드의 위치 설정
            RectTransform rectTransform = _cardHands[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(startX + i * spacing, rectTransform.anchoredPosition.y);
        }
    }
}
