using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public enum EBattleState
{
    MyTurnStart,
    MyTurn,
    MyTurnEnd,
    EnemyTurnStart,
    EnemyTurn,
    EnemyTurnEnd,
    BattleEnd,
}
public class BattleManager : MonoBehaviour
{
    static public BattleManager instance;

    public System.Action onStartMyTurn;     // 내 턴 시작 시 발생
    public System.Action onEndEnemyTurn;       // 내 턴 끝 시 발생

    private BattleData currentBattleData;
    public List<Enemy> enemyList;
    [SerializeField] GameObject EnemyTrans;
    private Coroutine coBattle = null;

    private BattleManagerStateFactory _stateFactory;

    public bool playerTurn = false;
    public bool myTurn;

    public int stage;

    private void Awake()
    {
        instance = this;
        stage = 1;
        _stateFactory = new(this);
    }

    public Enemy TargetEnemy(CardAttackArea cardAttackArea)
    {
        List<Enemy> newEnemys = new List<Enemy>(enemyList);

        // 정렬된 리스트를 새롭게 생성
        List<Enemy> sortedEnemys = newEnemys.OrderByDescending(enemy => enemy.CharacterStat.CurrentHp).ToList();

        // 정렬된 리스트를 이용하여 출력
        for (int i = 0; i < sortedEnemys.Count; i++)
        {
            Debug.Log(i + " 번째 몬스터 체력 : " + sortedEnemys[i].CharacterStat.CurrentHp);
        }

        if (enemyList != null)
        {
            switch (cardAttackArea)
            {
                case CardAttackArea.Forward:
                    return enemyList[0];
                case CardAttackArea.Middle:
                    return enemyList[(enemyList.Count / 2)];
                case CardAttackArea.Back:
                    return enemyList[enemyList.Count - 1];
                case CardAttackArea.Random:
                    return enemyList[Random.Range(0, enemyList.Count)];
                case CardAttackArea.All:
                    return null;//전부 다 공격은 그냥 enemyList꺼내다 쓰면 됨
                case CardAttackArea.MostHealth:
                    return sortedEnemys[0];
                case CardAttackArea.LeastHealth:
                    return sortedEnemys[sortedEnemys.Count - 1];
                case CardAttackArea.None:
                    return null;
            }
        }
        else
        {
            return null;
        }
        return null;
    }
    public void StartBattle(BattleData battleData)
    {
        playerTurn = true;
        myTurn= true;
        // 배틀데이터 저장
        currentBattleData = battleData;

        foreach(BaseCard baseCard in Player.instance.PlayerDeck)
        {
            baseCard.ChangeState(ECardUsage.Battle);
        }

        for(int i = 0; i < EnemyTrans.transform.childCount; i++)
        {
            Destroy(EnemyTrans.transform.GetChild(i).gameObject);
        }

        // 적 생성
        enemyList = new List<Enemy>();

        if(battleData.Enemies.Count == 1)
        {
            Enemy enemy = Object.Instantiate(battleData.Enemies[0], new Vector2(0, 2), Quaternion.identity, EnemyTrans.transform);
            enemyList.Add(enemy);
        }
        else if(battleData.Enemies.Count == 2)
        {
            Enemy enemy_1 = Object.Instantiate(battleData.Enemies[0], new Vector2(-0.65f, 2), Quaternion.identity, EnemyTrans.transform);
            enemyList.Add(enemy_1);

            Enemy enemy_2 = Object.Instantiate(battleData.Enemies[1], new Vector2(0.65f, 2), Quaternion.identity, EnemyTrans.transform);
            enemyList.Add(enemy_2);
        }
        else
        {
            Enemy enemy_1 = Object.Instantiate(battleData.Enemies[0], new Vector2(-1.3f, 2), Quaternion.identity, EnemyTrans.transform);
            enemyList.Add(enemy_1);

            Enemy enemy_2 = Object.Instantiate(battleData.Enemies[1], new Vector2(0, 2), Quaternion.identity, EnemyTrans.transform);
            enemyList.Add(enemy_2);

            Enemy enemy_3 = Object.Instantiate(battleData.Enemies[2], new Vector2(1.3f, 2), Quaternion.identity, EnemyTrans.transform);
            enemyList.Add(enemy_3);
        }

        _stateFactory.ChangeState(EBattleState.MyTurnStart);

        if (coBattle != null)
        {
            StopCoroutine(coBattle);
        }
        coBattle = StartCoroutine(CoBattle());
    }

    IEnumerator CoBattle()
    {
        while (true)
        {
            _stateFactory.CurrentState.Update();

            // 플레이어 죽음 확인
            if (Player.instance.PlayerState.IsDead)
                break;

            // 적 죽음 확인
            if (enemyList.Count == 0)
                break;

            yield return null;
        }

        if (Player.instance.PlayerState.IsDead)  // 플레이어가 죽었다.
        {
            //_gameScoreUI.GameOver();
            //GameManager.UI.ShowThisUI(_gameScoreUI);
        }
        else if (Player.instance.PlayerState.Height >= 16)  // 보스를 깼다...
        {
            //StartCoroutine(GameManager.Sound.FadeInOutAudioSource(EBGM.BossClear));

            //GameManager.UI.ShowThisUI(inGoEndingUI);
        }
        else
        {
            //onEndBattle?.Invoke();

            // 클리어 처리
            //GameManager.Game.CurrentRoom.ClearRoom();

            // 보상
            Debug.Log("보상을 줍니다.");
            RewardManager.instance.ShowReward(currentBattleData);
            //GameManager.UI.ShowThisUI(inRewardUI);
        }
    }

    public void EndTurn()//턴 종료 버튼 누르면 실행(카드 선택 금지, 적 공격 실행, 코스트 회복, 카드 드로우)
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
        playerTurn = false;
        myTurn = false;
        //카드 선택 안되게 변경

        /*
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].enemyPattern.Act();//모든 적의 패턴 실행
        }

        if(Player.instance.PlayerState.CurrentHp < 0)
        {
            //죽으면 게임 오버 로직 실행
        }
        */
        //Player.instance.PlayerState.CurrentOrb += 3;//코스트 회복(나중에 수치 정하기)

        //Player.instance.GenerateRandomCard();//카드 한장 드로우

        //playerTurn = true;
    }
}
