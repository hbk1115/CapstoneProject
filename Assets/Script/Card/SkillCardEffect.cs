using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardEffect : MonoBehaviour
{

    public void Matches() // 성냥
    {
        Player.instance.PlayerState.CurrentHp += 20; // 체력 20 회복
        CardHolder.instance.DrawCard();
    }

    public void Ice() // 얼음
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(1, Player.instance);
     
    }

    public void Scarecrow() // 허수아비
    {
        // 구현 내용 추가
    }

    public void Blightseed() // 역병씨앗
    {
        // 구현 내용 추가
    }

    public void Poisonarrow() // 독화살
    {
        // 구현 내용 추가
    }

    public void Toxictrap() // 맹독성함정
    {
        Player.instance.PlayerState.CurrentHp += 20;
    }

    public void Outbreak() // 창궐
    {
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
    }

    public void Toxicspores() // 독성포자
    {
        Player.instance.PlayerState.CurrentHp += 20;
    }
}