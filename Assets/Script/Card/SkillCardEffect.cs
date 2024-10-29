using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardEffect : MonoBehaviour
{
    public IndentData[] indentData; // CharacterIndent 배열 추가
    
    
    
    
    public void Matches() // 성냥
    {
        Player.instance.PlayerState.CurrentHp += 20; // 체력 20 회복
        CardHolder.instance.DrawCard();
    }



    public void Ice() //얼음
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

    public void Scarecrow() // 허수아비
    {
        // 모든 적에게 피해를 10 줌
        foreach (Enemy enemy in BattleManager.instance.enemyList)
        {
            enemy.Hit(15, Player.instance);
            Debug.Log($"Dealt 10 damage to: {enemy.name}");
        }

        // 플레이어 체력 회복
        Player.instance.PlayerState.CurrentHp += 20;
        Debug.Log("Player HP healed by 10.");
    }

    public void Blightseed() // 역병씨앗
    {
        // 맨 앞의 적 선택
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);
        if (target != null)
        {
            // 역병 상태 이상 데이터 가져오기
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                // 역병 상태 이상 부여
                target.CharacterIndent.AddIndent(plagueData, 1); // 예를 들어 1턴 동안 역병 적용
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

    public void PoisonArrow() // 독화살 안됨
    {
        // 중앙의 적을 타겟으로 설정
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Middle);

        // 타겟 확인
        if (target != null)
        {
            Debug.Log("타겟이 선택되었습니다: " + target.name);

            // 역병 상태 이상 데이터 가져오기
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];

            // 상태 이상 데이터 확인
            if (plagueData != null)
            {
                // 중앙의 적에게 역병 상태 이상 적용
                target.CharacterIndent.AddIndent(plagueData, 3); // 3턴 동안 역병 적용
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

    public void Toxictrap() // 맹독성함정
    {
        // 맨 뒤의 적 선택
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Back);

        if (target != null)
        {
            // 역병 상태 이상 부여
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                target.CharacterIndent.AddIndent(plagueData, 3); // 3턴 동안 역병 적용
                Debug.Log("Plague effect applied to: " + target.name);
            }
            else
            {
                Debug.LogError("Plague Indent Data is null!");
            }

            // 플레이어 체력 20 회복
            Player.instance.PlayerState.CurrentHp += 20;
            Debug.Log("Player healed for 20 HP.");
        }
        else
        {
            Debug.LogWarning("No target found for Toxictrap!");
        }
    }

    public void Outbreak() // 창궐
    {
        // 모든 적에게 역병 상태 이상 부여
        foreach (var enemy in BattleManager.instance.enemyList)
        {
            if (enemy != null)
            {
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    enemy.CharacterIndent.AddIndent(plagueData, 2); // 2턴 동안 역병 적용
                    Debug.Log("Plague effect applied to: " + enemy.name);
                }
                else
                {
                    Debug.LogError("Plague Indent Data is null!");
                }
            }
        }

        // 카드 두 장 뽑기
        CardHolder.instance.DrawCard(); // 첫 번째 카드 드로우
        CardHolder.instance.DrawCard(); // 두 번째 카드 드로우

        Debug.Log("Two cards drawn.");
    }

    public void ToxicSpores() // 독성 포자 안됨
    {
        // 모든 적에게 역병 상태 이상 부여
        foreach (var enemy in BattleManager.instance.enemyList)
        {
            if (enemy != null)
            {
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    enemy.CharacterIndent.AddIndent(plagueData, 2); // 2턴 동안 역병 적용
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