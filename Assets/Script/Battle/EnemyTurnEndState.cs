using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnEndState : BaseBattleState
{
    public EnemyTurnEndState(BattleManager battleManager, BattleManagerStateFactory stateFactory) : base(battleManager, stateFactory)
    {
        battleState = EBattleState.EnemyTurnEnd;
    }

    public override void Enter()
    {
        //_battleManager.onEndEnemyTurn?.Invoke();
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        BattleManager.instance.myTurn = true;
        BattleManager.instance.playerTurn = true;
        _stateFactory.ChangeState(EBattleState.MyTurnStart);
    }
}
