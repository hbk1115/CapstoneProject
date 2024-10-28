using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected enum EEnemyGrade { common, Elite, Boss }
    [SerializeField]
    protected EEnemyGrade _enemyGrade;

    public CharacterState CharacterStat { get; private set; }
    public EnemyPattern enemyPattern { get; private set; }
    public CharacterIndent CharacterIndent { get; private set; } // 추가된 상태 이상 관리

    public int enemyPower;

    protected virtual void Awake()
    {
        CharacterStat = GetComponent<CharacterState>();
        enemyPattern = GetComponent<EnemyPattern>();
        CharacterIndent = GetComponent<CharacterIndent>(); // CharacterIndent 초기화 추가

        CharacterStat.Init(this);
        enemyPattern.Init(this);

        CharacterStat.Power = enemyPower;
    }

    public override void Dead()
    {
        BattleManager.instance.enemyList.Remove(this);
        Destroy(this.gameObject);
    }

    public override void Hit(int damage, Character attacker)
    {
        CharacterStat.Hit(damage);
    }

    public override void Act()
    {
        Debug.Log("행동한당");
        // 상태 이상 시각화 또는 기타 행동 추가 가능
        // CharacterIndent.Visualize();
    }
}