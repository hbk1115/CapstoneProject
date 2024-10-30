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
    private Transform _cardDeckTransform; // ī�� �� ��ġ
    [SerializeField]
    private Transform _cardCemetryTransform; // ī�� ���� ��ġ
    [SerializeField]
    private Transform _cardExtinctionTransform; // ī�� �Ҹ� ��ġ

    [SerializeField]
    private TextMeshProUGUI _cardDeckCountText;
    [SerializeField]
    private TextMeshProUGUI _cardCemetryCountText;
    [SerializeField]
    private TextMeshProUGUI _cardExtinctionCountText;

    [SerializeField]
    private MyList<BaseCard> _cardDeck;  // ī�� ��
    [SerializeField]
    private MyList<BaseCard> _cardHands; // ī�� ��
    [SerializeField]
    private MyList<BaseCard> _cardCemetry; // ī�� ����
    [SerializeField]
    private MyList<BaseCard> _cardExtinction; // ī�� �Ҹ�

    private List<BaseCard> _temporaryList = new List<BaseCard>();

    //ī�� �̰�, ���� �� �ѱ� ��, ī�� �� ������ �ٽ� �̱� �����
    //�� �� �Ѿ�°� �ٽ� �Ҵ��ؼ� �����ϱ�(���� �� BattleManagerStateFactory���� ����)
    //�� �̿��� ī���� �����ӵ� ��� cardHolder���� �����ϵ��� ����

    private void Awake()
    {
        instance = this;
    }

    public void StartBattle(List<BaseCard> myCard)
    {
        isBattle = true;

        // �ʿ���� ī��� ����
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

        // �� ī�� �ֱ�
        foreach (BaseCard card in myCard)
        {
            // ��ġ �ʱ�ȭ
            card.transform.SetParent(_cardTransform);

            card.ChangeState(ECardUsage.Battle);

            card.transform.localPosition = _cardDeckTransform.localPosition;
            card.transform.localEulerAngles = Vector3.zero;
            card.transform.localScale = Vector3.zero;

            _cardDeck.Add(card);
        }

        // ����
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


    // �Ҹ�
    public void Extinction(BaseCard card)
    {
        _cardHands.Remove(card);
        _cardExtinction.Add(card);

        Relocation();

        // �Ҹ�� ī�尡 1���̶� ������ �Ҹ� UI ����
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
    /// ī�� ��ο�
    /// </summary>
    public void DrawCard()
    {
        // �п� ī�� 10���̻��̸� ���̻� ī�带 ��ο����� ����
        if (_cardHands.Count >= 10)
        {
            return;
        }

        // ���� ī�尡 ������ ������ �ִ� ī�带 ���� ���� �ְ� ������ ���� ��ο�
        if (_cardDeck.Count <= 0)
        {
            ReturnToDeck();
            Util.ShuffleList(_cardDeck);
        }

        // ���� �� �� �̾Ƽ� �п� ����
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
    // �ش� ī�尡 �п� ���°�ִ��� ��ȯ
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

    // ���� ī�� ���� ������ ��ȯ
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

    // �п� �ִ� ��� ī�� ������
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
        // ī�� ���� ����
        float spacing = 150f;

        // �߾� ������ ���� ���� ��ġ ���
        float totalWidth = (_cardHands.Count - 1) * spacing; // ��ü �ʺ� ���
        float startX = -totalWidth / 2; // ���� ��ġ (�߾� ������ ����)

        for (int i = 0; i < _cardHands.Count; i++)
        {
            _cardHands[i].GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);//��Ŀ �߾����� ����
            _cardHands[i].GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            _cardHands[i].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            _cardHands[i].transform.localEulerAngles = Vector3.zero; // ȸ�� �ʱ�ȭ
            _cardHands[i].transform.localScale = Vector3.one; // ������ �ʱ�ȭ

            // ī���� ��ġ ����
            RectTransform rectTransform = _cardHands[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(startX + i * spacing, rectTransform.anchoredPosition.y);
        }
    }
}
