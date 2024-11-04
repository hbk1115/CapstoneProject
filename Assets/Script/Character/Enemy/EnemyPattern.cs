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
    public List<Pattern> enemyPatterns;//��� ����
    public Image patternImage;
    public TextMeshProUGUI patternText;

    private Pattern currentPattern;
    

    public void Init(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Act()
    {
        ActPattern();//���� ����
    }

    public void DecidePattern()
    {
        int randNum = Random.Range(0, enemyPatterns.Count);

        currentPattern = enemyPatterns[randNum];//�������� ���� �����ֱ�

        //���� �̹��� ǥ���ϰ� ��ġ�� ǥ���ϱ�
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
