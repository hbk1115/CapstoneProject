using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardEffect : MonoBehaviour
{
    public IndentData[] indentData; // CharacterIndent 배열 추가

    public void SampleAttack(CardData cardData)
    {
        if (cardData.cardAttackArea != CardAttackArea.All)
        {
            BattleManager.instance.TargetEnemy(cardData.cardAttackArea).Hit(cardData.attackPower, Player.instance);
        }
        else
        {
            for (int i = 0; i < BattleManager.instance.enemyList.Count; i++)
            {
                BattleManager.instance.enemyList[i].Hit(cardData.attackPower, Player.instance);
            }
        }
    }

    public void Torch() //횃불
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(3, Player.instance);
    }

    public void BurningFlame() // 타오르는 불
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Random);
        if (target != null)
        {
            target.Hit(7, Player.instance);

            // 상태 이상 적용
            IndentData burnData = indentData[(int)IndentData.EIndent.Burn];
            if (burnData != null)
            {
                target.CharacterIndent.AddIndent(burnData, 2);
                Debug.Log("Burn effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Burn Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for Burning Flame!");
        }
    }

    public void Burningnail() //타오르는 못
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);
    }

    public void Bonfire() //모닥불
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Back).Hit(8, Player.instance);
    }

    public void Frozennail() //얼어붙은 못
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);
    }

    public void Waves() //파도
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Back).Hit(25, Player.instance);
        Player.instance.PlayerState.CurrentHp += 20; // 체력 20 회복
    }

    public void Icespear() //얼음창
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Random).Hit(50, Player.instance);
    }

    public void Icewhirlwind() //얼음 회오리
    {
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            BattleManager.instance.enemyList[i].Hit(10, Player.instance);
        }
    }

    public void Hoe() //호미
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(5, Player.instance);
    }

    public void Scythe() //낫
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Back).Hit(12, Player.instance);
    }

    public void Pickaxe() //곡괭이
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(16, Player.instance);
    }

    public void Oldcart() //낡은손수래
    {
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            BattleManager.instance.enemyList[i].Hit(7, Player.instance);
        }
    }
}
