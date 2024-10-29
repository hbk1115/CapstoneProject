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
        BattleManager.instance.TargetEnemy(CardAttackArea.Random).Hit(7, Player.instance);
    }
   

    public void Burningnail() //Ÿ������ ��
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);
    }

    public void Bonfire() //��ں�
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Back);
        if (target != null)
        {
            target.Hit(8, Player.instance);

            // ���� �̻� ����
            IndentData burnData = indentData[(int)IndentData.EIndent.Burn];
            if (burnData != null)
            {
                target.CharacterIndent.AddIndent(burnData, 1);
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



    public void Frozennail() //������ ��
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);
    }


    public void Waves() // �ĵ�
    {
        // �� ���� �� ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Back);

        if (target != null)
        {
            // ������ ���ظ� 25 �ֱ�
            target.Hit(25, Player.instance);
            Debug.Log($"{target.name}���� 25 ���ظ� �־����ϴ�.");

            // ���� ���� ������ ��� �÷��̾� ü�� ȸ��
            if (target.CharacterIndent.HasIndent(IndentData.EIndent.Freeze))
            {
                Player.instance.PlayerState.CurrentHp += 20;
                Debug.Log("���� ���� �����̹Ƿ� �÷��̾ 20 ü���� ȸ���߽��ϴ�.");
            }
            else
            {
                Debug.Log($"{target.name}�� ���� ���°� �ƴմϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("Ÿ���� ã�� �� �����ϴ�.");
        }
    }

    public void Icespear() // ����â
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Random);
        if (target != null)
        {
            target.Hit(10, Player.instance);

            IndentData freezeData = indentData[(int)IndentData.EIndent.Freeze];
            if (freezeData != null)
            {
                target.CharacterIndent.AddIndent(freezeData, 1);
                Debug.Log("Freeze effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Freeze Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for Frozennail!");
        }
    }

    public void Icewhirlwind() // ���� ȸ����
    {
        // ��� ������ ���ظ� 14 �ֱ�
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            BattleManager.instance.enemyList[i].Hit(14, Player.instance);
            Debug.Log($"{BattleManager.instance.enemyList[i].name}���� 14 ���ظ� �־����ϴ�.");
        }

        // �÷��̾� ü�� ȸ��
        Player.instance.PlayerState.CurrentHp += 5;
        Debug.Log("�÷��̾ 5 ü���� ȸ���߽��ϴ�.");
    }

    public void Hoe() // ȣ��
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);
        if (target != null)
        {
            target.Hit(5, Player.instance);

            // ���� ���� �̻� ����
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                target.CharacterIndent.AddIndent(plagueData, 3); // ���÷� 3�� ���� ���� ����
                Debug.Log("Plague effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Plague Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for Hoe!");
        }
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
