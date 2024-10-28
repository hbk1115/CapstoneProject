using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardEffect : MonoBehaviour
{
    public IndentData[] indentData; // CharacterIndent �迭 �߰�

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

    public void Torch() //ȶ��
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(3, Player.instance);
    }

    public void BurningFlame() // Ÿ������ ��
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Random);
        if (target != null)
        {
            target.Hit(7, Player.instance);

            // ���� �̻� ����
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

    public void Burningnail() //Ÿ������ ��
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);
    }

    public void Bonfire() //��ں�
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Back).Hit(8, Player.instance);
    }

    public void Frozennail() //������ ��
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);
    }

    public void Waves() //�ĵ�
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Back).Hit(25, Player.instance);
        Player.instance.PlayerState.CurrentHp += 20; // ü�� 20 ȸ��
    }

    public void Icespear() //����â
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Random).Hit(50, Player.instance);
    }

    public void Icewhirlwind() //���� ȸ����
    {
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            BattleManager.instance.enemyList[i].Hit(10, Player.instance);
        }
    }

    public void Hoe() //ȣ��
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(5, Player.instance);
    }

    public void Scythe() //��
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Back).Hit(12, Player.instance);
    }

    public void Pickaxe() //���
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(16, Player.instance);
    }

    public void Oldcart() //�����ռ���
    {
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            BattleManager.instance.enemyList[i].Hit(7, Player.instance);
        }
    }
}
