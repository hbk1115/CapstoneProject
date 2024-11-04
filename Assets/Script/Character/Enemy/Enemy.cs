using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IndentData;

public class Enemy : Character
{
    protected enum EEnemyGrade { common, Elite, Boss }
    [SerializeField]
    protected EEnemyGrade _enemyGrade;

    public CharacterState CharacterStat { get; private set; }
    public EnemyPattern enemyPattern { get; private set; }
    public CharacterIndent CharacterIndent { get; private set; } // �߰��� ���� �̻� ����

    public int enemyPower;

    protected virtual void Awake()
    {
        CharacterStat = GetComponent<CharacterState>();
        enemyPattern = GetComponent<EnemyPattern>();
        CharacterIndent = GetComponent<CharacterIndent>(); // CharacterIndent �ʱ�ȭ �߰�

        CharacterStat.Init(this);
        enemyPattern.Init(this);
        CharacterIndent.Init(this);

        CharacterStat.Power = enemyPower;

        BattleManager.instance.onStartMyTurn += OnStartMyTurn;
        BattleManager.instance.onEndEnemyTurn += OnEndEnemyTurn;
    }
    protected virtual void OnStartMyTurn()
    {
        enemyPattern.DecidePattern();
    }
    protected virtual void OnEndEnemyTurn()
    {
        CharacterIndent.UpdateIndents();
    }

    public override void Dead()
    {
        BattleManager.instance.enemyList.Remove(this);
        BattleManager.instance.onStartMyTurn -= OnStartMyTurn;
        BattleManager.instance.onEndEnemyTurn -= OnEndEnemyTurn;
        Destroy(this.gameObject);
    }

    public override void Hit(int damage, Character attacker)
    {
        // ���� ������ ��� ���ݷ� 30% ����
        if (indent[(int)EIndent.Plague])
        {
            damage += Mathf.RoundToInt(damage * 0.5f); // 20% �߰� ����
        }

        Debug.Log("�¾Ҵ�");
        CharacterStat.Hit(damage);
    }

    public override void Act()
    {
        Debug.Log("�ൿ�Ѵ�");
        // ���� �̻� �ð�ȭ �Ǵ� ��Ÿ �ൿ �߰� ����
        // CharacterIndent.Visualize();
    }
}