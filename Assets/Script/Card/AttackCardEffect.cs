using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardEffect : MonoBehaviour
{
    public IndentData[] indentData; // CharacterIndent 배열 추가

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

    public void Torch() //횃불
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(3, Player.instance);
    }

    public void BurningFlame() // 타오르는 불
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Random).Hit(7, Player.instance);
    }
   

    public void Burningnail() //타오르는 못
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);
    }

    public void Bonfire() //모닥불
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Back);
        if (target != null)
        {
            target.Hit(8, Player.instance);

            // 상태 이상 적용
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



    public void Frozennail() //얼어붙은 못
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(6, Player.instance);
    }


    public void Waves() // 파도
    {
        // 맨 뒤의 적 선택
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Back);

        if (target != null)
        {
            // 적에게 25 피해를 줍니다.
            target.Hit(25, Player.instance);
            Debug.Log($"{target.name}에게 25 피해를 주었습니다.");

            // 플레이어 체력 20 회복
            Player.instance.PlayerState.CurrentHp += 20;
            Debug.Log("플레이어가 20 체력을 회복했습니다.");
        }
        else
        {
            Debug.LogWarning("타겟을 찾을 수 없습니다.");
        }
    }

    public void Icespear() // 얼음창
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

    public void Icewhirlwind() // 얼음 회오리
    {
        // 모든 적에게 피해를 14 주기
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            BattleManager.instance.enemyList[i].Hit(14, Player.instance);
            Debug.Log($"{BattleManager.instance.enemyList[i].name}에게 14 피해를 주었습니다.");
        }

        // 플레이어 체력 회복
        Player.instance.PlayerState.CurrentHp += 5;
        Debug.Log("플레이어가 5 체력을 회복했습니다.");
    }

    public void Hoe() // 호미
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);
        if (target != null)
        {
            target.Hit(5, Player.instance);

            // 역병 상태 이상 적용
            IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
            if (plagueData != null)
            {
                target.CharacterIndent.AddIndent(plagueData, 3); // 예시로 3턴 동안 역병 적용
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

    public void Scythe() //낫
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Back).Hit(12, Player.instance);
    }

    public void Pickaxe() //곡괭이
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(16, Player.instance);
    }

    public void Oldcart() //낡은손수래
    {
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            BattleManager.instance.enemyList[i].Hit(7, Player.instance);
        }
    }

    public void ignition() //점화
    {
        // 맨 앞의 적 선택
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            // 화상 상태 이상 데이터 가져오기
            IndentData burnData = indentData[(int)IndentData.EIndent.Burn];

            if (burnData != null)
            {
                // 화상 상태 이상 부여
                target.CharacterIndent.AddIndent(burnData, 1); // 예를 들어 1턴 동안 화상 적용
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

    public void embers() //불씨
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(6, Player.instance);
    }

    public void Flameblade() //불꽃 칼날
    {
        // 맨 앞의 적 선택
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            // 적에게 8 피해를 줌
            target.Hit(8, Player.instance);
            Debug.Log($"{target.name}에게 8 피해를 주었습니다.");

            // 화상 상태 이상 데이터 가져오기
            IndentData burnData = indentData[(int)IndentData.EIndent.Burn];

            if (burnData != null)
            {
                // 화상 상태 이상 부여
                target.CharacterIndent.AddIndent(burnData, 1); // 예시로 1턴 동안 화상 적용
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

    public void wateringcan() // 물뿌리개
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Forward).Hit(3, Player.instance);
    }

    public void shower() //소나기
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Random).Hit(7, Player.instance);
    }

    public void Iceblade() //얼음칼날
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Forward);

        if (target != null)
        {
            // 맨 앞의 적에게 8의 피해를 줌
            target.Hit(8, Player.instance);

            // 동상 상태 이상 부여
            IndentData freezeData = indentData[(int)IndentData.EIndent.Freeze];
            if (freezeData != null)
            {
                target.CharacterIndent.AddIndent(freezeData, 1); // 예시로 1턴 동안 동상 적용
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

    public void Icearrow() //얼음 화살
    {
        Enemy target = BattleManager.instance.TargetEnemy(CardAttackArea.Middle);

        if (target != null)
        {
            // 중앙의 적에게 12의 피해를 줌
            target.Hit(12, Player.instance);

            // 동상 상태 이상 부여 (1턴 동안 지속)
            IndentData freezeData = indentData[(int)IndentData.EIndent.Freeze];
            if (freezeData != null)
            {
                target.CharacterIndent.AddIndent(freezeData, 1); // 1턴 동안 동상 적용
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
 
    public void hammer() //망치
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(8, Player.instance);
    }

    public void saw() //톱
    {
        BattleManager.instance.TargetEnemy(CardAttackArea.Middle).Hit(20, Player.instance);
    }
    
    public void thorn() //가시
    {
        // 모든 적에게 역병 상태 이상을 부여하고 10의 피해를 줌
        foreach (var enemy in BattleManager.instance.enemyList)
        {
            if (enemy != null)
            {
                // 역병 상태 데이터 가져오기
                IndentData plagueData = indentData[(int)IndentData.EIndent.Plague];
                if (plagueData != null)
                {
                    // 1턴 동안 역병 적용
                    enemy.CharacterIndent.AddIndent(plagueData, 1);
                    Debug.Log("Plague effect applied to: " + enemy.name);
                }
                else
                {
                    Debug.LogError("Plague Indent Data is null!");
                }

                // 적에게 10의 피해를 줌
                enemy.Hit(10, Player.instance);
                Debug.Log($"{enemy.name}에게 10의 피해를 주었습니다.");
            }
        }
    }
}
