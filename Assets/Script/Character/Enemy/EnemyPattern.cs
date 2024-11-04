using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

[System.Serializable]
public class Pattern
{
    public EnemyPatternData patternData;
    public int value;
}

public class EnemyPattern : MonoBehaviour
{
    private Enemy enemy;
    //[SerializeField] private EnemyPatternData enemyPattern;
    public List<Pattern> enemyPatterns;//모든 패턴
    public Image patternImage;
    public TextMeshProUGUI patternText;

    private Pattern currentPattern;
    

    public void Init(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Act()
    {
        ActPattern();//공격 실행
    }

    public void DecidePattern()
    {
        int randNum = Random.Range(0, enemyPatterns.Count);

        currentPattern = enemyPatterns[randNum];//랜덤으로 패턴 정해주기

        //패턴 이미지 표시하고 수치도 표시하기
        patternImage.sprite = currentPattern.patternData.patternIcon;
        patternText.text = currentPattern.value.ToString();
    }

    private void ActPattern()
    {
        switch (currentPattern.patternData.patternType)
        {
            case EPatternType.Attack:
                Player.instance.Hit(currentPattern.value, enemy);
                break;
            case EPatternType.Defense:
                enemy.CharacterStat.CurrentHp += currentPattern.value;
                break;
            case EPatternType.BuffAttack:
                enemy.CharacterStat.CurrentHp += currentPattern.value;
                Player.instance.Hit(currentPattern.value, enemy);
                break;
        }
    }
}
