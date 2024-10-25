using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardEffect : MonoBehaviour
{
    public void SampleAttack(CardData cardData)
    {
        if(cardData.cardAttackArea != CardAttackArea.All)
        {
            BattleManager.instance.TargetEnemy(cardData.cardAttackArea).Hit(cardData.attackPower, Player.instance);
        }
        else
        {
            for(int i = 0; i < BattleManager.instance.enemyList.Count; i++)
            {
                BattleManager.instance.enemyList[i].Hit(cardData.attackPower, Player.instance);
            }
        }
    }

    public void Torch()
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(3, Player.instance);
        //TargetEnemy = 어떤 적을 때릴지
    }

    public void HealthUp()
    {
        Player.instance.PlayerState.CurrentHp += 5;
    }
}
