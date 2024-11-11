using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;
using static IndentData;

public class Player : Character
{
    static public Player instance;
    public int CurrentEnergy { get; set; } = 10; // �⺻ ������
    //public CardGenerator CardGenerator; // CardGenerator �ν��Ͻ�
    public List<BaseCard> PlayerDeck = new List<BaseCard>(); // �÷��̾��� ī�� ��
    public PlayerState PlayerState { get; private set; }
    public CharacterIndent CharacterIndent { get; private set; } // �߰��� ���� �̻� ����

    void Awake()
    {
        instance = this;
        Init();
        ShowPlayerDeck(); // ���� �÷��̾� �� ǥ��
        BattleManager.instance.onEndEnemyTurn += OnEndEnemyTurn;
    }

    void Init()
    {
        CharacterIndent = GetComponent<CharacterIndent>();
        PlayerState = GetComponent<PlayerState>();
        
        CharacterIndent.Init(this);
        PlayerState.Init(this);
    }
    protected virtual void OnEndEnemyTurn()
    {
        CharacterIndent.UpdateIndents();
        Debug.Log("update indent");
    }

    // ī�� ���� �޼���
    public void GenerateCard(string cardName)
    {

        BaseCard generatedCard = CardGenerator.instance.GenerateCard(cardName);

        if (generatedCard == null || generatedCard.cardData == null) // null üũ �߰�
        {
            Debug.LogError("generatedCard �Ǵ� CardData�� null�Դϴ�. ī�� ������ �����߽��ϴ�."); // �߰� �α�
            return; // ������ ī�尡 null�� ��� �޼��� ����
        }

        Debug.Log($"{generatedCard.cardData.cardName} ī�尡 �����Ǿ����ϴ�.");
        PlayerDeck.Add(generatedCard); // �÷��̾��� ���� �߰�
    }

    // ���� ī�� ���� �޼���
    public void GenerateRandomCard()
    {
        if (CardGenerator.instance.AllCardList == null || CardGenerator.instance.AllCardList.Count == 0)
        {
            Debug.LogError("ī�� ����Ʈ�� ����־� ���� ī�带 ������ �� �����ϴ�.");
            return; // ī�� ����Ʈ�� ��������� �޼��� ����
        }

        int randomIndex = Random.Range(0, CardGenerator.instance.AllCardList.Count); // ���� �ε��� ����
        CardData randomCardData = CardGenerator.instance.AllCardList[randomIndex]; // ���� ī�� ������ ����
        GenerateCard(randomCardData.cardName); // ������ ī�� �����ͷ� ī�� ����
    }

    // ī�� ��� Ȯ��
    public void ShowPlayerDeck()
    {
        Debug.Log("�÷��̾� ��:");
        foreach (var card in PlayerDeck)
        {
            Debug.Log($"- {card}");
        }
    }
    public void AddCard(BaseCard card)
    {
        PlayerDeck.Add(card);
    }
    public void RemoveCard(BaseCard card)
    {
        if (PlayerDeck.Count > 10)
        {
            PlayerDeck.Remove(card);
        }
    }

    public override void Dead()
    {
        //throw new System.NotImplementedException();
        this.gameObject.SetActive(false);
        UIManager.instance.OpenGameOverWindow();

    }

    public override void Hit(int damage, Character attacker)
    {
        // ���� ���� Ȯ��
        if (attacker is Enemy enemy && enemy.indent[(int)EIndent.Freeze])
        {
            damage = Mathf.RoundToInt(damage * 0.7f);// 70%�� ����
            Debug.Log("Plague effect applied, damage increased to " + damage);
        }

        AudioManager.instance.PlaySfx(AudioManager.Sfx.player_hit);
        PlayerState.Hit(damage); // �÷��̾��� ü�� ���� ó��
        Debug.Log($"{name} was hit with {damage} damage.");
    }
    public override void Act()
    {
        throw new System.NotImplementedException();
    }
}