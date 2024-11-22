using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IndentData;
using static UnityEngine.GraphicsBuffer;

public class SkillCardEffect : BaseCardEffect
{
    public void Matches(CardData cardData) // ����
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // ü�� 20 ȸ��
        SpawnEffect(cardData);
    }

    public void Ice(CardData cardData) // ����.
    {
        IndentEffect(cardData, IndentData.EIndent.Freeze);
    }

    public void Scarecrow(CardData cardData) // ����ƺ�
    {
        TargetAllHit(cardData);

        // �÷��̾� ü�� ȸ��
        Player.instance.PlayerState.CurrentHp += cardData.defensePower;
    }

    public void Blightseed(CardData cardData) // ��������
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void PoisonArrow(CardData cardData) // ��ȭ��
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void Toxictrap(CardData cardData) // �͵�������
    {
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target.indent[(int)EIndent.Plague])
        {
            Player.instance.PlayerState.CurrentHp += 20;
        }

        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void Outbreak(CardData cardData) // â��
    {
        IndentAllEffect(cardData, IndentData.EIndent.Plague);

        // ī�� �� �� �̱�
        CardHolder.instance.DrawCard(); // ù ��° ī�� ��ο�
        CardHolder.instance.DrawCard(); // �� ��° ī�� ��ο�
    }

    public void ToxicSpores(CardData cardData) // ���� ����
    {
        IndentAllEffect(cardData, IndentData.EIndent.Plague);

        Player.instance.PlayerState.CurrentHp += cardData.defensePower;
    }

    public void RedPotion(CardData cardData) //����ǥ��
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // ü�� 50 ȸ��
        SpawnEffect(cardData);
    }

    public void Flames(CardData cardData) // �ұ�
    {
        IndentAllEffect(cardData, IndentData.EIndent.Burn);

        CardHolder.instance.DrawCard(); // ù ��° ī�� ��ο�
        CardHolder.instance.DrawCard(); // �� ��° ī�� ��ο�;
    }

    public void Bottle(CardData cardData)  // ����
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower;
        CardHolder.instance.DrawCard();
        SpawnEffect(cardData);
    }
    public void FishingRod(CardData cardData)  //���ô�
    {
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);
        TargetHit(cardData, target);
        IndentEffect(cardData, IndentData.EIndent.Freeze, target);
    }

    public void WoodenBox(CardData cardData)  //��������
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower;

        CardHolder.instance.DrawCard();
        SpawnEffect(cardData);
    }

    public void Basket(CardData cardData)  //�ٱ���
    {
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
        SpawnEffect(cardData);
    }

    public void SwarmOfRats(CardData cardData)  //�� ��
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void LeafBlade(CardData cardData)  //�ٻ�� Į��
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void Seeds(CardData cardData)  //����
    {
        SpawnEffect(cardData);
        CardHolder.instance.DrawCard();
    }

    public void FallenLeaves(CardData cardData) //����
    {
        SpawnEffect(cardData);
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // ü�� 50 ȸ��
    }

    public void Rustyaxe(CardData cardData)  //�콼 ����
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void Sturdyaxe(CardData cardData)  //ưư�� ����
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void Heavysnow(CardData cardData) // ����
    {
        IndentAllEffect(cardData, IndentData.EIndent.Freeze);

        CardHolder.instance.DrawCard(); // ù ��° ī�� ��ο�
        CardHolder.instance.DrawCard(); // �� ��° ī�� ��ο�;
    }

    public void Hellfire(CardData cardData)  //������
    {
        IndentEffect(cardData, IndentData.EIndent.Burn);
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // ü�� 10 ȸ��
    }

    public void Frostywind(CardData cardData)  //�����ٶ�
    {
        IndentEffect(cardData, IndentData.EIndent.Freeze);
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // ü�� 20 ȸ��
    }

}