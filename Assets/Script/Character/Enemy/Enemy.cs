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
    public CharacterIndent CharacterIndent { get; private set; } // �߰��� ���� �̻� ����

    public int enemyPower;

    protected virtual void Awake()
    {
        CharacterStat = GetComponent<CharacterState>();
        enemyPattern = GetComponent<EnemyPattern>();
        CharacterIndent = GetComponent<CharacterIndent>(); // CharacterIndent �ʱ�ȭ �߰�

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
        Debug.Log("�ൿ�Ѵ�");
        // ���� �̻� �ð�ȭ �Ǵ� ��Ÿ �ൿ �߰� ����
        // CharacterIndent.Visualize();
    }
}