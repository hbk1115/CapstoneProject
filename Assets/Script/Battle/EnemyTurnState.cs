using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : BaseBattleState
{
    float actTime = 0.01f;
    float currentTime = 0f;
    int enemyIndex = 0;

    int enemyCount = 0;

    public EnemyTurnState(BattleManager battleManager, BattleManagerStateFactory stateFactory) : base(battleManager, stateFactory)
    {
        battleState = EBattleState.EnemyTurn;
    }

    public override void Enter()
    {
        currentTime = 0f;
        enemyIndex = 0;
        enemyCount = BattleManager.instance.enemyList.Count;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > actTime)
        {
            _battleManager.enemyList[enemyIndex].enemyPattern.Act();
            currentTime = 0;
            enemyIndex++;
        }

        // 적 행동 다 하면 상태 전환
        if (enemyIndex == enemyCount)
        {
            _stateFactory.ChangeState(EBattleState.EnemyTurnEnd);
        }
    }
}
