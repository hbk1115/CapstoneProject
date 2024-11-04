using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EPatternType
{
    Attack,
    Defense,
    Debuff,
    Buff,
    BuffAttack
}

[CreateAssetMenu()]
public class EnemyPatternData : ScriptableObject
{
    public EPatternType patternType;
    public Sprite patternIcon;
    public string patternName;
    [Multiline(5)]
    public string patternExplanation;
}
