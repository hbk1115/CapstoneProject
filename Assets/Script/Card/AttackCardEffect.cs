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

    public void Torch(CardData cardData) //ȶ��
    {
        TargetHit(cardData);
    }

    public void BurningFlame(CardData cardData) // Ÿ������ ��
    {
        TargetHit(cardData);
    }


    public void Burningnail(CardData cardData) //Ÿ������ ��
    {
        TargetHit(cardData);
    }

    public void Burnfire(CardData cardData) //��ں�
    {
        IndentEffect(cardData, EIndent.Burn);
        TargetHit(cardData);
    }

    public void FrozenNail(CardData cardData) //������ ��
    {
        TargetHit(cardData);
    }


    public void Waves(CardData cardData) // �ĵ�
    {
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target != null)
        {
            if (target.indent[(int)EIndent.Freeze])//�����̸� ȸ��
            {
                Player.instance.PlayerState.CurrentHp += cardData.defensePower;
            }
        }

        TargetHit(cardData);
    }

    public void IceSpear(CardData cardData) // ����â
    {
        List<Enemy> enemies = new List<Enemy>(BattleManager.instance.enemyList);//���ο� �� ����Ʈ
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

    public void Icewhirlwind(CardData cardData) // ���� ȸ����
    {
        TargetAllHit(cardData);

        Player.instance.PlayerState.CurrentHp += cardData.defensePower;
    }

    public void Hoe(CardData cardData) // ȣ��
    {
        TargetHit(cardData);
    }

    public void Scythe(CardData cardData) //��
    {
        TargetHit(cardData);
    }

    public void Pickaxe(CardData cardData) //���
    {
        TargetHit(cardData);
    }

    public void Oldcart(CardData cardData) //�����ռ���
    {
        TargetAllHit(cardData);
    }

    public void Ignition(CardData cardData) //��ȭ
    {
        IndentEffect(cardData, EIndent.Burn);
    }

    public void Embers(CardData cardData) //�Ҿ�
    {
        TargetHit(cardData);
    }

    public void Flameblade(CardData cardData) //�Ҳ� Į��
    {
        IndentEffect(cardData, EIndent.Burn);
        TargetHit(cardData);
    }

    public void WateringCan(CardData cardData) // ���Ѹ���
    {
        TargetHit(cardData);
        Player.instance.PlayerState.CurrentOrb += 1;
    }

    public void Shower(CardData cardData) //�ҳ���
    {
        TargetHit(cardData);
    }

    public void Iceblade(CardData cardData) //����Į��
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Icearrow(CardData cardData) //���� ȭ��
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Hammer(CardData cardData) //��ġ
    {
        TargetHit(cardData);
    }

    public void Saw(CardData cardData) //��
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Thorn(CardData cardData) //����
    {
        IndentAllEffect(cardData, EIndent.Plague);
        TargetAllHit(cardData);
    }
}
