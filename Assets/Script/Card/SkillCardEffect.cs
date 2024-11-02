using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SkillCardEffect : MonoBehaviour
{
    public IndentData[] indentData; // CharacterIndent 배열 추가




    public void Matches() // 성냥
    {
        Player.instance.PlayerState.CurrentHp += 3; // 체력 20 회복
        CardHolder.instance.DrawCard();
    }



    public void Ice() // 얼음.
    {
        // 앞쪽의 적을 타겟으로 설정
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            Debug.Log("타겟이 선택되었습니다: " + target.name);

            // 동상 상태 이상 데이터 가져오기
            IndentData freezeData = indentData[(int)IndentData.EIndent.Freeze];

            if (freezeData != null)
            {
                // 앞쪽의 적에게 동상 상태 이상 적용
                target.CharacterIndent.AddIndent(freezeData, 1); // 예를 들어 1턴 동안 동상 적용
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

    public void Scarecrow() // 허수아비
    {
        // 모든 적에게 피해를 10 줌
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            BattleManager.instance.enemyList[i].Hit(15, Player.instance);
        }

        // 플레이어 체력 회복
        Player.instance.PlayerState.CurrentHp += 20;
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

    public void PoisonArrow() // 독화살
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
                target.CharacterIndent.AddIndent(plagueData, 1); // 1턴 동안 역병 적용
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
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            if (BattleManager.instance.enemyList[i] != null)
            {
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    BattleManager.instance.enemyList[i].CharacterIndent.AddIndent(plagueData, 2); // 2턴 동안 역병 적용
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

    public void ToxicSpores() // 독성 포자
    {
        // 모든 적에게 역병 상태 이상 부여
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            if (BattleManager.instance.enemyList[i] != null)
            {
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    BattleManager.instance.enemyList[i].CharacterIndent.AddIndent(plagueData, 1); // 1턴 동안 역병 적용
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

    public void redpotion() //빨간표션
    {
        Player.instance.PlayerState.CurrentHp += 50; // 체력 50 회복
    }

    public void flames() // 불길
    {
        // 모든 적에게 화상 상태를 부여
        IndentData burnData = indentData[(int)IndentData.EIndent.Burn];

        if (burnData != null)
        {
            for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
            {
                Enemy target = BattleManager.instance.enemyList[i];
                target.CharacterIndent.AddIndent(burnData, 1); // 예시로 1턴 동안 화상 적용
            }
        }
        else
        {
            Debug.LogError("Burn Indent Data is null!");
        }

        CardHolder.instance.DrawCard(); // 첫 번째 카드 드로우
        CardHolder.instance.DrawCard(); // 두 번째 카드 드로우;

        Debug.Log("Player drew 2 cards.");
    }

    public void bottle()  // 물병
    {
        // 체력 20 회복
        Player.instance.PlayerState.CurrentHp += 20;

        // 카드 한 장 드로우
        CardHolder.instance.DrawCard();
    }
    public void fishingrod()  //낚시대
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);

        // 앞쪽의 적을 타겟으로 설정
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Middle);

        if (target != null)
        {
            Debug.Log("타겟이 선택되었습니다: " + target.name);

            // 동상 상태 이상 데이터 가져오기
            IndentData freezeData = indentData[(int)IndentData.EIndent.Freeze];

            if (freezeData != null)
            {
                // 앞쪽의 적에게 동상 상태 이상 적용
                target.CharacterIndent.AddIndent(freezeData, 1); // 예를 들어 1턴 동안 동상 적용
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

    public void woodenbox()  //나무상자
    {
        Player.instance.PlayerState.CurrentHp += 20;

        CardHolder.instance.DrawCard();
    }

    public void basket()  //나무상자
    {
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
        CardHolder.instance.DrawCard();
    }

    public void swarmofrats()  //쥐 떼
    {
        // 맨 뒤의 적 선택
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Back);

        if (target != null)
        {
            // 역병 상태 이상 데이터 가져오기
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                // 두 번 역병 상태이상 적용
                target.CharacterIndent.AddIndent(plagueData, 2); // 2턴적용
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

    public void leafblade()  //잎사귀 칼날
    {
        // 맨 뒤의 적 선택
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            // 역병 상태 이상 데이터 가져오기
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                // 두 번 역병 상태이상 적용
                target.CharacterIndent.AddIndent(plagueData, 2); // 2턴적용
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

    public void seeds()  //씨앗
    {
        CardHolder.instance.DrawCard();
    }

    public void fallenleaves() //낙엽
    {
        Player.instance.PlayerState.CurrentHp += 30; // 체력 50 회복
    }
}