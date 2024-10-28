using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardEffect : MonoBehaviour
{

    public void Matches() // ����
    {
        Player.instance.PlayerState.CurrentHp += 20; // ü�� 20 ȸ��
        CardHolder.instance.DrawCard();
    }

    public void Ice() // ����
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(1, Player.instance);
     
    }

    public void Scarecrow() // ����ƺ�
    {
        // ���� ���� �߰�
    }

    public void Blightseed() // ��������
    {
        // ���� ���� �߰�
    }

    public void Poisonarrow() // ��ȭ��
    {
        // ���� ���� �߰�
    }

    public void Toxictrap() // �͵�������
    {
        Player.instance.PlayerState.CurrentHp += 20;
    }

    public void Outbreak() // â��
    {
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
    }

    public void Toxicspores() // ��������
    {
        Player.instance.PlayerState.CurrentHp += 20;
    }
}