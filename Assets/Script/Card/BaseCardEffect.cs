using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IndentData;

public class BaseCardEffect : MonoBehaviour
{
    public IndentData[] indentData; // CharacterIndent 배열 추가
    public void TargetHit(CardData cardData, Enemy targetEnemy = null)
    {
        if(targetEnemy != null)
        {
            Enemy target = targetEnemy;
            int damage = cardData.attackPower;

            if (target != null)
            {
                if (target.indent[(int)EIndent.Plague])
                {
                    damage += Mathf.RoundToInt(damage * 0.5f); // 20% 추가 피해
                }
                SpawnEffect(cardData, targetEnemy);
                SpawnDamageText(cardData, damage, targetEnemy);
                target.Hit(damage, Player.instance);
            }
        }
        else
        {
            Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);
            int damage = cardData.attackPower;

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

    public void TargetAllHit(CardData cardData)
    {
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            //BattleManager.instance.enemyList[i].Hit(cardData.attackPower, Player.instance);

            Enemy target = BattleManager.instance.enemyList[i];
            int damage = cardData.attackPower;

            if (target != null)
            {
                if (target.indent[(int)EIndent.Plague])
                {
                    damage += Mathf.RoundToInt(damage * 0.5f); // 20% 추가 피해
                }
                SpawnEffect(cardData);
                SpawnDamageText(cardData, damage);
                target.Hit(damage, Player.instance);
            }
        }
    }

    public void IndentEffect(CardData cardData, EIndent indent, Enemy targetEnemy = null)
    {
        if(targetEnemy != null)//랜덤이면 타격 대상이랑 맞춰줘야함(여기에 뭐 적혀있으면 타겟 동기화
        {
            Enemy target = targetEnemy;//타겟 동일 지정

            if (target != null)
            {
                IndentData indentEffect = indentData[(int)indent];

                if (indentEffect != null)
                {
                    SpawnEffect(cardData, targetEnemy);
                    target.CharacterIndent.AddIndent(indentEffect, cardData.indentLength);
                }
            }
        }
        else
        {
            Enemy target = BattleManager.instance.TargetEnemy(cardData.cardAttackArea);
            if (target != null)
            {
                IndentData indentEffect = indentData[(int)indent];

                if (indentEffect != null)
                {
                    SpawnEffect(cardData, target);
                    target.CharacterIndent.AddIndent(indentEffect, cardData.indentLength);
                }
            }
        }
    }
    public void IndentAllEffect(CardData cardData, EIndent indent)
    {
        for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
        {
            if (BattleManager.instance.enemyList[i] != null)
            {
                IndentData indentEffect = indentData[(int)indent];

                if (indentEffect != null)
                {
                    SpawnEffect(cardData);
                    BattleManager.instance.enemyList[i].CharacterIndent.AddIndent(indentEffect, cardData.indentLength);
                }
            }
        }
    }

    public void SpawnEffect(CardData cardData, Enemy targetEnemy = null)
    {
        if (cardData.cardAttackArea == CardAttackArea.All)
        {
            for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
            {
                GameObject newEffect = EffectManager.instance.GetEffect(cardData);
                newEffect.transform.position = BattleManager.instance.enemyList[i].transform.position;
            }
        }
        else if (cardData.cardAttackArea == CardAttackArea.Player)
        {
            GameObject newEffect = EffectManager.instance.GetEffect(cardData);
            newEffect.transform.position = Player.instance.transform.position;
        }
        else
        {
            if(targetEnemy != null)
            {
                GameObject newEffect = EffectManager.instance.GetEffect(cardData);
                newEffect.transform.position = targetEnemy.transform.position;
            }
            else
            {
                GameObject newEffect = EffectManager.instance.GetEffect(cardData);
                newEffect.transform.position = BattleManager.instance.TargetEnemy(cardData.cardAttackArea).transform.position;
            }
        }
    }

    public void SpawnDamageText(CardData cardData, int damage, Enemy targetEnemy = null)
    {
        if (cardData.cardType != CardType.Resource)
        {
            if (cardData.cardAttackArea == CardAttackArea.All)
            {
                for (int i = BattleManager.instance.enemyList.Count - 1; i >= 0; i--)
                {
                    GameObject newEffect = EffectManager.instance.GetDamageText(cardData, damage);
                    newEffect.transform.position = BattleManager.instance.enemyList[i].transform.position + new Vector3(0, 0.7f, 0);
                }
            }
            else if (cardData.cardAttackArea == CardAttackArea.Player)
            {
                GameObject newEffect = EffectManager.instance.GetDamageText(cardData, damage);
                newEffect.transform.position = Player.instance.transform.position + new Vector3(0, 0.7f, 0);
            }
            else
            {
                if (targetEnemy != null)
                {
                    GameObject newEffect = EffectManager.instance.GetDamageText(cardData, damage);
                    newEffect.transform.position = targetEnemy.transform.position + new Vector3(0, 0.7f, 0);
                }
                else
                {
                    GameObject newEffect = EffectManager.instance.GetDamageText(cardData, damage);
                    newEffect.transform.position = BattleManager.instance.TargetEnemy(cardData.cardAttackArea).transform.position + new Vector3(0, 0.7f, 0);
                }
                
            }
        }
    }
}
