using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class IndentData : ScriptableObject
{
    public enum EIndent
    {
        Burn,    // 화상
        Freeze,  // 동상
        Plague,  // 역병
        Size,
    }

    public EIndent indent;
    public Sprite indentSprite;
    public string indentName;
    [Multiline(5)]
    public string indentExplanation;
    public bool isTurn;   // 턴이 지날수록 감소하는 indent인지
    public bool isShowTurn;

    public static implicit operator IndentData(CharacterIndent v)
    {
        throw new NotImplementedException();
    }
}