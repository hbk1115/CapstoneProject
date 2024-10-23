using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTurnState : BaseBattleState
{
    public MyTurnState(BattleManager battleManager, BattleManagerStateFactory stateFactory) : base(battleManager, stateFactory)
    {
        battleState = EBattleState.MyTurn;
    }

    // µå·Î¿ì
    public override void Enter()
    {
        for (int i = 0; i < 5; i++)
        {
            CardHolder.instance.DrawCard();
        }
    }

    public override void Exit()
    {
        //BattleManager.instance.myTurn = false;
    }

    public override void Update()
    {
        if (!_battleManager.myTurn)
        {
            _stateFactory.ChangeState(EBattleState.MyTurnEnd);
        }
    }
}
