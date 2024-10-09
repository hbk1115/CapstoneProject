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


    protected virtual void Awake()
    {

        CharacterStat = GetComponent<CharacterState>();

        CharacterStat.Init(this);
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    public override void Hit(int damage, Character attacker)
    {
        throw new System.NotImplementedException();
    }
}
