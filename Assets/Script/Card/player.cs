using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;
using static IndentData;

public class Player : Character
{
    static public Player instance;
    public int CurrentEnergy { get; set; } = 10; // 기본 에너지
    //public CardGenerator CardGenerator; // CardGenerator 인스턴스
    public List<BaseCard> PlayerDeck = new List<BaseCard>(); // 플레이어의 카드 덱
    public PlayerState PlayerState { get; private set; }
    public CharacterIndent CharacterIndent { get; private set; } // 추가된 상태 이상 관리

    void Awake()
    {
        instance = this;
        Init();
        ShowPlayerDeck(); // 현재 플레이어 덱 표시
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

    // 카드 생성 메서드
    public void GenerateCard(string cardName)
    {

        BaseCard generatedCard = CardGenerator.instance.GenerateCard(cardName);

        if (generatedCard == null || generatedCard.cardData == null) // null 체크 추가
        {
            Debug.LogError("generatedCard 또는 CardData가 null입니다. 카드 생성이 실패했습니다."); // 추가 로그
            return; // 생성된 카드가 null일 경우 메서드 종료
        }

        Debug.Log($"{generatedCard.cardData.cardName} 카드가 생성되었습니다.");
        PlayerDeck.Add(generatedCard); // 플레이어의 덱에 추가
    }

    // 랜덤 카드 생성 메서드
    public void GenerateRandomCard()
    {
        if (CardGenerator.instance.AllCardList == null || CardGenerator.instance.AllCardList.Count == 0)
        {
            Debug.LogError("카드 리스트가 비어있어 랜덤 카드를 생성할 수 없습니다.");
            return; // 카드 리스트가 비어있으면 메서드 종료
        }

        int randomIndex = Random.Range(0, CardGenerator.instance.AllCardList.Count); // 랜덤 인덱스 생성
        CardData randomCardData = CardGenerator.instance.AllCardList[randomIndex]; // 랜덤 카드 데이터 선택
        GenerateCard(randomCardData.cardName); // 선택한 카드 데이터로 카드 생성
    }

    // 카드 목록 확인
    public void ShowPlayerDeck()
    {
        Debug.Log("플레이어 덱:");
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
        // 역병 상태 확인
        if (attacker is Enemy enemy && enemy.indent[(int)EIndent.Freeze])
        {
            damage = Mathf.RoundToInt(damage * 0.7f);// 70%의 피해
            Debug.Log("Plague effect applied, damage increased to " + damage);
        }

        AudioManager.instance.PlaySfx(AudioManager.Sfx.player_hit);
        PlayerState.Hit(damage); // 플레이어의 체력 감소 처리
        Debug.Log($"{name} was hit with {damage} damage.");
    }
    public override void Act()
    {
        throw new System.NotImplementedException();
    }
}