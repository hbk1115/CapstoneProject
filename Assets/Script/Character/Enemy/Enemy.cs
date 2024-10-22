using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;

public class Enemy : Character
{
    protected enum EEnemyGrade { common, Elite, Boss }
    [SerializeField]
    protected EEnemyGrade _enemyGrade;

    public CharacterState CharacterStat { get; private set; }
    public EnemyPattern enemyPattern { get; private set; }

    public int enemyPower;


    protected virtual void Awake()
    {
        CharacterStat = GetComponent<CharacterState>();
        enemyPattern = GetComponent<EnemyPattern>();

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

        //EnemyPattern.Act();
        //StartCoroutine(CharacterAnimation.CoAct(false));
        //CharacterIndent.Visualize();
    }
}
