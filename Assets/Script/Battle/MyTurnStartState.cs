using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTurnStartState : BaseBattleState
{
    public MyTurnStartState(BattleManager battleManager, BattleManagerStateFactory stateFactory) : base(battleManager, stateFactory)
    {
        battleState = EBattleState.MyTurnStart;
    }

    public override void Enter()
    {
        Player.instance.PlayerState.CurrentOrb += 3;//코스트 회복(나중에 수치 정하기)
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if (BattleManager.instance.playerTurn)
        {
            _stateFactory.ChangeState(EBattleState.MyTurn);
        }
    }
}
