using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SkillCardEffect : BaseCardEffect
{
    public void Matches(CardData cardData) // ����
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // ü�� 20 ȸ��
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
    }

    public void Basket(CardData cardData)  //��������
    {
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
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
        CardHolder.instance.DrawCard();
    }

    public void FallenLeaves(CardData cardData) //����
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // ü�� 50 ȸ��
    }
}