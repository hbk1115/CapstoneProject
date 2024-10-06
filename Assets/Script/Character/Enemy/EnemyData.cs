using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyType
{
    Normal,
    Elite,
    Boss
}

[CreateAssetMenu()]
public class EnemyData : ScriptableObject
{
    public EnemyType enemyType;
    public Sprite enemySprite;
    public Animator enemyAnimator;
    public string enemyName;
    public float maxHealth;
    public float defensePower;
    public float attackPower;

    [Header("∆–≈œ")]
    public List<UnityEvent> usePattern;
}
