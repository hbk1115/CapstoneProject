using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IndentData;

public class AttackCardEffect : BaseCardEffect
{
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

    public void Torch(CardData cardData) //횃불
    {
        TargetHit(cardData);
    }

    public void BurningFlame(CardData cardData) // 타오르는 불
    {
        TargetHit(cardData);
    }


    public void Burningnail(CardData cardData) //타오르는 못
    {
        TargetHit(cardData);
    }

    public void Burnfire(CardData cardData) //모닥불
    {
        IndentEffect(cardData, EIndent.Burn);
        TargetHit(cardData);
    }

    public void FrozenNail(CardData cardData) //얼어붙은 못
    {
        TargetHit(cardData);
    }


    public void Waves(CardData cardData) // 파도
    {
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target != null)
        {
            if (target.indent[(int)EIndent.Freeze])//동상이면 회복
            {
                Player.instance.PlayerState.CurrentHp += cardData.defensePower;
            }
        }

        TargetHit(cardData);
    }

    public void IceSpear(CardData cardData) // 얼음창
    {
        List<Enemy> enemies = new List<Enemy>(BattleManager.instance.enemyList);//새로운 적 리스트
        List<Enemy> freezeEnemies = new();

        foreach (Enemy enemy in enemies)
        {
            if (enemy.indent[(int)EIndent.Freeze])
            {
                freezeEnemies.Add(enemy);
            }
        }

        if (freezeEnemies.Count > 0)
        {
            int randEnemyNum = Random.Range(0, freezeEnemies.Count);

            Enemy target = freezeEnemies[randEnemyNum];

            if (target != null)
            {
                TargetHit(cardData, target);
            }
        }
    }

    public void Icewhirlwind(CardData cardData) // 얼음 회오리
    {
        TargetAllHit(cardData);

        Player.instance.PlayerState.CurrentHp += cardData.defensePower;
    }

    public void Hoe(CardData cardData) // 호미
    {
        TargetHit(cardData);
    }

    public void Scythe(CardData cardData) //낫
    {
        TargetHit(cardData);
    }

    public void Pickaxe(CardData cardData) //곡괭이
    {
        TargetHit(cardData);
    }

    public void Oldcart(CardData cardData) //낡은손수래
    {
        TargetAllHit(cardData);
    }

    public void Ignition(CardData cardData) //점화
    {
        IndentEffect(cardData, EIndent.Burn);
    }

    public void Embers(CardData cardData) //불씨
    {
        TargetHit(cardData);
    }

    public void Flameblade(CardData cardData) //불꽃 칼날
    {
        IndentEffect(cardData, EIndent.Burn);
        TargetHit(cardData);
    }

    public void WateringCan(CardData cardData) // 물뿌리개
    {
        TargetHit(cardData);
        Player.instance.PlayerState.CurrentOrb += 1;
    }

    public void Shower(CardData cardData) //소나기
    {
        TargetHit(cardData);
    }

    public void Iceblade(CardData cardData) //얼음칼날
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Icearrow(CardData cardData) //얼음 화살
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Hammer(CardData cardData) //망치
    {
        TargetHit(cardData);
    }

    public void Saw(CardData cardData) //톱
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Thorn(CardData cardData) //흉작
    {
        IndentAllEffect(cardData, EIndent.Plague);
        TargetAllHit(cardData);
    }

    public void Plaguespit(CardData cardData) // 역병의침
    {
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target != null)
        {
            if (target.indent[(int)EIndent.Plague])
            {
                TargetHit(cardData);

                if (target.CharacterStat.CurrentHp > 0)
                {
                    if (BattleManager.instance.enemyList.Count > 0)
                    {
                        TargetHit(cardData);
                    }
                }
            }
            else
            {
                TargetHit(cardData);
            }
        }
    }

    public void frozenaxe(CardData cardData) //얼어붙은 도끼
    {
        // 체력이 가장 적은 적을 찾음
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target != null)
        {
            // 첫 번째 공격
            TargetHit(cardData);

            // 첫 번째 공격 후 적이 처치되었으면 한 번 더 공격
            if (target.CharacterStat.CurrentHp <= 0)
            {
                if (BattleManager.instance.enemyList.Count > 0)
                {
                    Enemy target_2 = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

                    if (target_2 != null)
                    {
                        TargetHit(cardData);
                    }
                }
            }
        }
    }

    public void Ironaxe(CardData cardData) //쇠도끼
    {
        // 체력이 가장 적은 적을 찾음
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target != null)
        {
            // 첫 번째 공격
            TargetHit(cardData);
        }
    }

    public void Burningaxe(CardData cardData)//불타는 도끼
    {
        // 체력이 가장 적은 적을 찾음
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target != null)
        {
            // 첫 번째 공격
            TargetHit(cardData);

            // 첫 번째 공격 후 적이 처치되었으면 한 번 더 공격
            if (target.CharacterStat.CurrentHp <= 0)
            {
                if(BattleManager.instance.enemyList.Count > 0)
                {
                    Enemy target_2 = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

                    if (target_2 != null)
                    {
                        TargetHit(cardData);
                    }
                }
            }
        }
    }

    public void Chill(CardData cardData) //한기
    {
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target != null)
        {
            TargetHit(cardData);

            if(target.CharacterStat.CurrentHp > 0)
            {
                if (target.indent[(int)EIndent.Freeze])
                {
                    int damage = 7;

                    if (target != null)
                    {
                        if (target.indent[(int)EIndent.Plague])
                        {
                            damage += Mathf.RoundToInt(damage * 0.5f); // 20% 추가 피해
                        }
                        SpawnEffect(cardData, target);
                        SpawnDamageText(cardData, damage, target);
                        target.Hit(damage, Player.instance);
                    }
                }
            }
        }
    }

    public void Snowman(CardData cardData) //눈사람
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Fireball(CardData cardData) // 화염구
    {
        List<Enemy> enemies = new List<Enemy>(BattleManager.instance.enemyList);//새로운 적 리스트
        List<Enemy> brunEnemies = new();

        foreach (Enemy enemy in enemies)
        {
            if (enemy.indent[(int)EIndent.Burn])
            {
                brunEnemies.Add(enemy);
            }
        }

        if (brunEnemies.Count > 0)
        {
            int randEnemyNum = Random.Range(0, brunEnemies.Count);

            Enemy target = brunEnemies[randEnemyNum];

            if (target != null)
            {
                TargetHit(cardData, target);
            }
        }
    }

    public void Firearrow(CardData cardData) //불꽃 화살
    {
        IndentEffect(cardData, EIndent.Burn);
        TargetHit(cardData);
    }

    public void Portabledrill(CardData cardData) //휴대용 석궁
    {
        Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);

        if (target != null)
        {
            // 첫 번째 공격
            TargetHit(cardData);

            
            if (target.CharacterStat.CurrentHp <= 0)
            {
                Player.instance.PlayerState.CurrentHp += 20;
            }
        }
    }

    public void Filthbomb(CardData cardData) // 오물폭탄
    {
        List<Enemy> enemies = new List<Enemy>(BattleManager.instance.enemyList);//새로운 적 리스트
        List<Enemy> plagueEnemies = new();

        foreach (Enemy enemy in enemies)
        {
            if (enemy.indent[(int)EIndent.Plague])
            {
                plagueEnemies.Add(enemy);
            }
        }

        if (plagueEnemies.Count > 0)
        {
            int randEnemyNum = Random.Range(0, plagueEnemies.Count);

            Enemy target = plagueEnemies[randEnemyNum];

            if (target != null)
            {
                TargetHit(cardData, target);
            }
        }
    }

    public void Icesword(CardData cardData) //얼음검
    {
        IndentEffect(cardData, EIndent.Freeze);
        TargetHit(cardData);
    }

    public void Flamesword(CardData cardData) //화염검
    {
        IndentEffect(cardData, EIndent.Burn);
        TargetHit(cardData);
    }

    public void Plaguesword(CardData cardData) //역병검
    {
        IndentEffect(cardData, EIndent.Plague);
        TargetHit(cardData);
    }

    public void Magma(CardData cardData) // 마그마

    {
        List<Enemy> enemies = new List<Enemy>(BattleManager.instance.enemyList);//새로운 적 리스트
        List<Enemy> brunEnemies = new();

        foreach (Enemy enemy in enemies)
        {
            if (enemy.indent[(int)EIndent.Burn])
            {
                brunEnemies.Add(enemy);
            }
        }

        if (brunEnemies.Count > 0)
        {
            int randEnemyNum = Random.Range(0, brunEnemies.Count);

            Enemy target = brunEnemies[randEnemyNum];

            if (target != null)
            {
                TargetHit(cardData, target);
            }
        }
    }

    public void Pollution(CardData cardData) // 오염
    {
        List<Enemy> enemies = new List<Enemy>(BattleManager.instance.enemyList);//새로운 적 리스트
        List<Enemy> plagueEnemies = new();

        foreach (Enemy enemy in enemies)
        {
            if (enemy.indent[(int)EIndent.Plague])
            {
                plagueEnemies.Add(enemy);
            }
        }

        if (plagueEnemies.Count > 0)
        {
            int randEnemyNum = Random.Range(0, plagueEnemies.Count);

            Enemy target = plagueEnemies[randEnemyNum];

            if (target != null)
            {
                TargetHit(cardData, target);
            }
        }
    }
}

