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

    public System.Action onStartMyTurn;     // �� �� ���� �� �߻�
    public System.Action onEndEnemyTurn;       // �� �� �� �� �߻�

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

        // ���ĵ� ����Ʈ�� ���Ӱ� ����
        List<Enemy> sortedEnemys = newEnemys.OrderByDescending(enemy => enemy.CharacterStat.CurrentHp).ToList();

        // ���ĵ� ����Ʈ�� �̿��Ͽ� ���
        for (int i = 0; i < sortedEnemys.Count; i++)
        {
            Debug.Log(i + " ��° ���� ü�� : " + sortedEnemys[i].CharacterStat.CurrentHp);
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
                    return null;//���� �� ������ �׳� enemyList������ ���� ��
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
        // ��Ʋ������ ����
        currentBattleData = battleData;

        foreach(BaseCard baseCard in Player.instance.PlayerDeck)
        {
            baseCard.ChangeState(ECardUsage.Battle);
        }

        for(int i = 0; i < EnemyTrans.transform.childCount; i++)
        {
            Destroy(EnemyTrans.transform.GetChild(i).gameObject);
        }

        // �� ����
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

            // �÷��̾� ���� Ȯ��
            if (Player.instance.PlayerState.IsDead)
                break;

            // �� ���� Ȯ��
            if (enemyList.Count == 0)
                break;

            yield return null;
        }

        if (Player.instance.PlayerState.IsDead)  // �÷��̾ �׾���.
        {
            //_gameScoreUI.GameOver();
            //GameManager.UI.ShowThisUI(_gameScoreUI);
        }
        else if (Player.instance.PlayerState.Height >= 16)  // ������ ����...
        {
            //StartCoroutine(GameManager.Sound.FadeInOutAudioSource(EBGM.BossClear));

            //GameManager.UI.ShowThisUI(inGoEndingUI);
        }
        else
        {
            //onEndBattle?.Invoke();

            // Ŭ���� ó��
            //GameManager.Game.CurrentRoom.ClearRoom();

            // ����
            Debug.Log("������ �ݴϴ�.");
            RewardManager.instance.ShowReward(currentBattleData);
            //GameManager.UI.ShowThisUI(inRewardUI);
        }
    }

    public void EndTurn()//�� ���� ��ư ������ ����(ī�� ���� ����, �� ���� ����, �ڽ�Ʈ ȸ��, ī�� ��ο�)
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.select_button);
        playerTurn = false;
        myTurn = false;
        //ī�� ���� �ȵǰ� ����

        /*
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].enemyPattern.Act();//��� ���� ���� ����
        }

        if(Player.instance.PlayerState.CurrentHp < 0)
        {
            //������ ���� ���� ���� ����
        }
        */
        //Player.instance.PlayerState.CurrentOrb += 3;//�ڽ�Ʈ ȸ��(���߿� ��ġ ���ϱ�)

        //Player.instance.GenerateRandomCard();//ī�� ���� ��ο�

        //playerTurn = true;
    }
}
