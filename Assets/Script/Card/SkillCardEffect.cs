using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SkillCardEffect : MonoBehaviour
{
    public IndentData[] indentData; // CharacterIndent �迭 �߰�




    public void Matches() // ����
    {
        Player.instance.PlayerState.CurrentHp += 3; // ü�� 20 ȸ��
        CardHolder.instance.DrawCard();
    }



    public void Ice() // ����.
    {
        // ������ ���� Ÿ������ ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            Debug.Log("Ÿ���� ���õǾ����ϴ�: " + target.name);

            // ���� ���� �̻� ������ ��������
            IndentData freezeData = indentData[(int)IndentData.EIndent.Freeze];

            if (freezeData != null)
            {
                // ������ ������ ���� ���� �̻� ����
                target.CharacterIndent.AddIndent(freezeData, 1); // ���� ��� 1�� ���� ���� ����
                Debug.Log("Freeze effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Freeze Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for Ice!");
        }
    }

    public void Scarecrow() // ����ƺ�
    {
        // ��� ������ ���ظ� 10 ��
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            BattleManager.instance.enemyList[i].Hit(15, Player.instance);
        }

        // �÷��̾� ü�� ȸ��
        Player.instance.PlayerState.CurrentHp += 20;
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

    public void PoisonArrow() // ��ȭ��
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
                target.CharacterIndent.AddIndent(plagueData, 1); // 1�� ���� ���� ����
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
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            if (BattleManager.instance.enemyList[i] != null)
            {
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    BattleManager.instance.enemyList[i].CharacterIndent.AddIndent(plagueData, 2); // 2�� ���� ���� ����
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

    public void ToxicSpores() // ���� ����
    {
        // ��� ������ ���� ���� �̻� �ο�
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            if (BattleManager.instance.enemyList[i] != null)
            {
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    BattleManager.instance.enemyList[i].CharacterIndent.AddIndent(plagueData, 1); // 1�� ���� ���� ����
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

    public void redpotion() //����ǥ��
    {
        Player.instance.PlayerState.CurrentHp += 50; // ü�� 50 ȸ��
    }

    public void flames() // �ұ�
    {
        // ��� ������ ȭ�� ���¸� �ο�
        IndentData burnData = indentData[(int)IndentData.EIndent.Burn];

        if (burnData != null)
        {
            for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
            {
                Enemy target = BattleManager.instance.enemyList[i];
                target.CharacterIndent.AddIndent(burnData, 1); // ���÷� 1�� ���� ȭ�� ����
            }
        }
        else
        {
            Debug.LogError("Burn Indent Data is null!");
        }

        CardHolder.instance.DrawCard(); // ù ��° ī�� ��ο�
        CardHolder.instance.DrawCard(); // �� ��° ī�� ��ο�;

        Debug.Log("Player drew 2 cards.");
    }

    public void bottle()  // ����
    {
        // ü�� 20 ȸ��
        Player.instance.PlayerState.CurrentHp += 20;

        // ī�� �� �� ��ο�
        CardHolder.instance.DrawCard();
    }
    public void fishingrod()  //���ô�
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);

        // ������ ���� Ÿ������ ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Middle);

        if (target != null)
        {
            Debug.Log("Ÿ���� ���õǾ����ϴ�: " + target.name);

            // ���� ���� �̻� ������ ��������
            IndentData freezeData = indentData[(int)IndentData.EIndent.Freeze];

            if (freezeData != null)
            {
                // ������ ������ ���� ���� �̻� ����
                target.CharacterIndent.AddIndent(freezeData, 1); // ���� ��� 1�� ���� ���� ����
                Debug.Log("Freeze effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Freeze Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found for Ice!");
        }
    }

    public void woodenbox()  //��������
    {
        Player.instance.PlayerState.CurrentHp += 20;

        CardHolder.instance.DrawCard();
    }

    public void basket()  //��������
    {
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
    }

    public void swarmofrats()  //�� ��
    {
        // �� ���� �� ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Back);

        if (target != null)
        {
            // ���� ���� �̻� ������ ��������
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                // �� �� ���� �����̻� ����
                target.CharacterIndent.AddIndent(plagueData, 2); // 2������
            }
            else
            {
                Debug.LogError("Plague Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found at the back.");
        }
    }

    public void leafblade()  //�ٻ�� Į��
    {
        // �� ���� �� ����
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            // ���� ���� �̻� ������ ��������
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                // �� �� ���� �����̻� ����
                target.CharacterIndent.AddIndent(plagueData, 2); // 2������
            }
            else
            {
                Debug.LogError("Plague Indent Data is null!");
            }
        }
        else
        {
            Debug.LogWarning("No target found at the back.");
        }
    }

    public void seeds()  //����
    {
        CardHolder.instance.DrawCard();
    }

    public void fallenleaves() //����
    {
        Player.instance.PlayerState.CurrentHp += 30; // ü�� 50 ȸ��
    }
}