using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTurnEndState : BaseBattleState
{
    public MyTurnEndState(BattleManager battleManager, BattleManagerStateFactory stateFactory) : base(battleManager, stateFactory)
    {
        battleState = EBattleState.MyTurnEnd;
    }

    public override void Enter()
    {
        //BattleManager.instance.onEndMyTurn?.Invoke();
        CardHolder.instance.DiscardAllCard();
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        _stateFactory.ChangeState(EBattleState.EnemyTurnStart);
    }
}
