using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SkillCardEffect : BaseCardEffect
{
    public void Matches(CardData cardData) // 성냥
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // 체력 20 회복
    }

    public void Ice(CardData cardData) // 얼음.
    {
        IndentEffect(cardData, IndentData.EIndent.Freeze);
    }

    public void Scarecrow(CardData cardData) // 허수아비
    {
        TargetAllHit(cardData);

        // 플레이어 체력 회복
        Player.instance.PlayerState.CurrentHp += cardData.defensePower;
    }

    public void Blightseed(CardData cardData) // 역병씨앗
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void PoisonArrow(CardData cardData) // 독화살
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void Toxictrap(CardData cardData) // 맹독성함정
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void Outbreak(CardData cardData) // 창궐
    {
        IndentAllEffect(cardData, IndentData.EIndent.Plague);

        // 카드 두 장 뽑기
        CardHolder.instance.DrawCard(); // 첫 번째 카드 드로우
        CardHolder.instance.DrawCard(); // 두 번째 카드 드로우
    }

    public void ToxicSpores(CardData cardData) // 독성 포자
    {
        IndentAllEffect(cardData, IndentData.EIndent.Plague);

        Player.instance.PlayerState.CurrentHp += cardData.defensePower;
    }

    public void RedPotion(CardData cardData) //빨간표션
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // 체력 50 회복
    }

    public void Flames(CardData cardData) // 불길
    {
        IndentAllEffect(cardData, IndentData.EIndent.Burn);

        CardHolder.instance.DrawCard(); // 첫 번째 카드 드로우
        CardHolder.instance.DrawCard(); // 두 번째 카드 드로우;
    }

    public void Bottle(CardData cardData)  // 물병
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower;
        CardHolder.instance.DrawCard();
    }
    public void FishingRod(CardData cardData)  //낚시대
    {
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);
        TargetHit(cardData, target);
        IndentEffect(cardData, IndentData.EIndent.Freeze, target);
    }

    public void WoodenBox(CardData cardData)  //나무상자
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower;

        CardHolder.instance.DrawCard();
    }

    public void Basket(CardData cardData)  //나무상자
    {
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
    }

    public void SwarmOfRats(CardData cardData)  //쥐 떼
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void LeafBlade(CardData cardData)  //잎사귀 칼날
    {
        IndentEffect(cardData, IndentData.EIndent.Plague);
    }

    public void Seeds(CardData cardData)  //씨앗
    {
        CardHolder.instance.DrawCard();
    }

    public void FallenLeaves(CardData cardData) //낙엽
    {
        Player.instance.PlayerState.CurrentHp += cardData.defensePower; // 체력 50 회복
    }
}