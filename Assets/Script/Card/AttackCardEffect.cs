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
            // ������ 25 ���ظ� �ݴϴ�.
            target.Hit(25, Player.instance);
            Debug.Log($"{target.name}���� 25 ���ظ� �־����ϴ�.");

            // �÷��̾� ü�� 20 ȸ��
            Player.instance.PlayerState.CurrentHp += 20;
            Debug.Log("�÷��̾ 20 ü���� ȸ���߽��ϴ�.");
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

    public void ignition() //��ȭ
    {
        // �� ���� �� ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            // ȭ�� ���� �̻� ������ ��������
            IndentData burnData = indentData[(int)IndentData.EIndent.Burn];

            if (burnData != null)
            {
                // ȭ�� ���� �̻� �ο�
                target.CharacterIndent.AddIndent(burnData, 1); // ���� ��� 1�� ���� ȭ�� ����
                Debug.Log("Burn effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Burn Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for Torch!");
        }
    }

    public void embers() //�Ҿ�
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(6, Player.instance);
    }

    public void Flameblade() //�Ҳ� Į��
    {
        // �� ���� �� ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            // ������ 8 ���ظ� ��
            target.Hit(8, Player.instance);
            Debug.Log($"{target.name}���� 8 ���ظ� �־����ϴ�.");

            // ȭ�� ���� �̻� ������ ��������
            IndentData burnData = indentData[(int)IndentData.EIndent.Burn];

            if (burnData != null)
            {
                // ȭ�� ���� �̻� �ο�
                target.CharacterIndent.AddIndent(burnData, 1); // ���÷� 1�� ���� ȭ�� ����
                Debug.Log("Burn effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Burn Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for Torch!");
        }
    }

    public void wateringcan() // ���Ѹ���
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(3, Player.instance);
    }

    public void shower() //�ҳ���
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Random).Hit(7, Player.instance);
    }

    public void Iceblade() //����Į��
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            // �� ���� ������ 8�� ���ظ� ��
            target.Hit(8, Player.instance);

            // ���� ���� �̻� �ο�
            IndentData freezeData = indentData[(int)IndentData.EIndent.Freeze];
            if (freezeData != null)
            {
                target.CharacterIndent.AddIndent(freezeData, 1); // ���÷� 1�� ���� ���� ����
                Debug.Log("Freeze effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Freeze Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for Frostbite!");
        }
    }

    public void Icearrow() //���� ȭ��
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Middle);

        if (target != null)
        {
            // �߾��� ������ 12�� ���ظ� ��
            target.Hit(12, Player.instance);

            // ���� ���� �̻� �ο� (1�� ���� ����)
            IndentData freezeData = indentData[(int)IndentData.EIndent.Freeze];
            if (freezeData != null)
            {
                target.CharacterIndent.AddIndent(freezeData, 1); // 1�� ���� ���� ����
                Debug.Log("Freeze effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Freeze Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for FrostImpact!");
        }
    }
 
    public void hammer() //��ġ
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(8, Player.instance);
    }

    public void saw() //��
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(20, Player.instance);
    }
    
    public void thorn() //����
    {
        // ��� ������ ���� ���� �̻��� �ο��ϰ� 10�� ���ظ� ��
        foreach (var enemy in BattleManager.instance.enemyList)
        {
            if (enemy != null)
            {
                // ���� ���� ������ ��������
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    // 1�� ���� ���� ����
                    enemy.CharacterIndent.AddIndent(plagueData, 1);
                    Debug.Log("Plague effect applied to: " + enemy.name);
                }
                else
                {
                    Debug.LogError("Plague Indent Data is null!");
                }

                // ������ 10�� ���ظ� ��
                enemy.Hit(10, Player.instance);
                Debug.Log($"{enemy.name}���� 10�� ���ظ� �־����ϴ�.");
            }
        }
    }
}
