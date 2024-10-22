using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour
{
    private Enemy enemy;
    [SerializeField] private EnemyPatternData enemyPattern;

    public void Init(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Act()
    {
        ActPattern();//공격 실행
    }

    private void ActPattern()
    {
        switch (enemyPattern.patternType)
        {
            case EPatternType.Attack:
                Player.instance.Hit(enemy.CharacterStat.Power, enemy);
                break;
            case EPatternType.Defense:
                //enemy.CharacterStat.Shield += _currentPattern.amount + _enemy.CharacterStat.Agility;
                break;
            case EPatternType.Debuff:
                //GameManager.Sound.PlaySE(ESE.Debuff);
                //GetIndent();
                break;
            case EPatternType.Buff:
                //GameManager.Sound.PlaySE(ESE.Buff);
                //GetIndent();
                break;
        }
    }
}
