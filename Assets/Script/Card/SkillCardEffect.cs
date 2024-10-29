using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardEffect : MonoBehaviour
{
    public IndentData[] indentData; // CharacterIndent �迭 �߰�
    
    
    
    
    public void Matches() // ����
    {
        Player.instance.PlayerState.CurrentHp += 20; // ü�� 20 ȸ��
        CardHolder.instance.DrawCard();
    }



    public void Ice() //����
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);
        if (target != null)
        {
            target.Hit(1, Player.instance);

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

    public void Scarecrow() // ����ƺ�
    {
        // ��� ������ ���ظ� 10 ��
        foreach (Enemy enemy in BattleManager.instance.enemyList)
        {
            enemy.Hit(15, Player.instance);
            Debug.Log($"Dealt 10 damage to: {enemy.name}");
        }

        // �÷��̾� ü�� ȸ��
        Player.instance.PlayerState.CurrentHp += 20;
        Debug.Log("Player HP healed by 10.");
    }

    public void Blightseed() // ��������
    {
        // �� ���� �� ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);
        if (target != null)
        {
            // ���� ���� �̻� ������ ��������
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                // ���� ���� �̻� �ο�
                target.CharacterIndent.AddIndent(plagueData, 1); // ���� ��� 1�� ���� ���� ����
                Debug.Log("Plague effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Plague Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for Blightseed!");
        }
    }

    public void PoisonArrow() // ��ȭ�� �ȵ�
    {
        // �߾��� ���� Ÿ������ ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Middle);

        // Ÿ�� Ȯ��
        if (target != null)
        {
            Debug.Log("Ÿ���� ���õǾ����ϴ�: " + target.name);

            // ���� ���� �̻� ������ ��������
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];

            // ���� �̻� ������ Ȯ��
            if (plagueData != null)
            {
                // �߾��� ������ ���� ���� �̻� ����
                target.CharacterIndent.AddIndent(plagueData, 3); // 3�� ���� ���� ����
                Debug.Log("Plague effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Plague Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for PoisonArrow!");
        }
    }

    public void Toxictrap() // �͵�������
    {
        // �� ���� �� ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Back);

        if (target != null)
        {
            // ���� ���� �̻� �ο�
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                target.CharacterIndent.AddIndent(plagueData, 3); // 3�� ���� ���� ����
                Debug.Log("Plague effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Plague Indent Data is null!");
            }

            // �÷��̾� ü�� 20 ȸ��
            Player.instance.PlayerState.CurrentHp += 20;
            Debug.Log("Player healed for 20 HP.");
        }
        else
        {
            Debug.LogWarning("No target found for Toxictrap!");
        }
    }

    public void Outbreak() // â��
    {
        // ��� ������ ���� ���� �̻� �ο�
        foreach (var enemy in BattleManager.instance.enemyList)
        {
            if (enemy != null)
            {
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    enemy.CharacterIndent.AddIndent(plagueData, 2); // 2�� ���� ���� ����
                    Debug.Log("Plague effect applied to: " + enemy.name);
                }
                else
                {
                    Debug.LogError("Plague Indent Data is null!");
                }
            }
        }

        // ī�� �� �� �̱�
        CardHolder.instance.DrawCard(); // ù ��° ī�� ��ο�
        CardHolder.instance.DrawCard(); // �� ��° ī�� ��ο�

        Debug.Log("Two cards drawn.");
    }

    public void ToxicSpores() // ���� ���� �ȵ�
    {
        // ��� ������ ���� ���� �̻� �ο�
        foreach (var enemy in BattleManager.instance.enemyList)
        {
            if (enemy != null)
            {
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    enemy.CharacterIndent.AddIndent(plagueData, 2); // 2�� ���� ���� ����
                    Debug.Log("Plague effect applied to: " + enemy.name);
                }
                else
                {
                    Debug.LogError("Plague Indent Data is null!");
                }
            }
        }
        Player.instance.PlayerState.CurrentHp += 20;
        Debug.Log("Player healed for 20 HP.");

    }
}