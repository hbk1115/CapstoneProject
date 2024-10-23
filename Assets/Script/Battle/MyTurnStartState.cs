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
        CardHolder.instance.StartBattle(Player.instance.PlayerDeck);//ó�� ī�� �ʱ�ȭ
        Player.instance.PlayerState.CurrentOrb = Player.instance.PlayerState.MaxOrb;
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
