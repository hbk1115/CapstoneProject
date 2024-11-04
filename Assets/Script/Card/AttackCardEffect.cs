using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IndentData;

public class AttackCardEffect : BaseCardEffect
{
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

    public void Torch(CardData cardData) //횃불
    {
        TargetHit(cardData);
    }

    public void BurningFlame(CardData cardData) // 타오르는 불
    {
        TargetHit(cardData);
    }


    public void Burningnail(CardData cardData) //타오르는 못
    {
        TargetHit(cardData);
    }

    public void Burnfire(CardData cardData) //모닥불
    {
        IndentEffect(cardData, EIndent.Burn);
        TargetHit(cardData);
    }

    public void FrozenNail(CardData cardData) //얼어붙은 못
    {
        TargetHit(cardData);
    }


    public void Waves(CardData cardData) // 파도
    {
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target != null)
        {
            if (target.indent[(int)EIndent.Freeze])//동상이면 회복
            {
                Player.instance.PlayerState.CurrentHp += cardData.defensePower;
            }
        }

        TargetHit(cardData);
    }

    public void IceSpear(CardData cardData) // 얼음창
    {
        List<Enemy> enemies = new List<Enemy>(BattleManager.instance.enemyList);//새로운 적 리스트
        List<Enemy> freezeEnemies = new();

        foreach (Enemy enemy in enemies)
        {
            if (enemy.indent[(int)EIndent.Freeze])
            {
                freezeEnemies.Add(enemy);
            }
        }

        if (freezeEnemies.Count > 0)
        {
            int randEnemyNum = Random.Range(0, freezeEnemies.Count);

            Enemy target = freezeEnemies[randEnemyNum];

            if (target != null)
            {
                TargetHit(cardData, target);
            }
        }
    }

    public void Icewhirlwind(CardData cardData) // 얼음 회오리
    {
        TargetAllHit(cardData);

        Player.instance.PlayerState.CurrentHp += cardData.defensePower;
    }

    public void Hoe(CardData cardData) // 호미
    {
        TargetHit(cardData);
    }

    public void Scythe(CardData cardData) //낫
    {
        TargetHit(cardData);
    }

    public void Pickaxe(CardData cardData) //곡괭이
    {
        TargetHit(cardData);
    }

    public void Oldcart(CardData cardData) //낡은손수래
    {
        TargetAllHit(cardData);
    }

    public void Ignition(CardData cardData) //점화
    {
        IndentEffect(cardData, EIndent.Burn);
    }

    public void Embers(CardData cardData) //불씨
    {
        TargetHit(cardData);
    }

    public void Flameblade(CardData cardData) //불꽃 칼날
    {
        IndentEffect(cardData, EIndent.Burn);
        TargetHit(cardData);
    }

    public void WateringCan(CardData cardData) // 물뿌리개
    {
        TargetHit(cardData);
        Player.instance.PlayerState.CurrentOrb += 1;
    }

    public void Shower(CardData cardData) //소나기
    {
        TargetHit(cardData);
    }

    public void Iceblade(CardData cardData) //얼음칼날
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Icearrow(CardData cardData) //얼음 화살
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Hammer(CardData cardData) //망치
    {
        TargetHit(cardData);
    }

    public void Saw(CardData cardData) //톱
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Thorn(CardData cardData) //흉작
    {
        IndentAllEffect(cardData, EIndent.Plague);
        TargetAllHit(cardData);
    }
}
