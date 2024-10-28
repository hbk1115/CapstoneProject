using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class IndentData : ScriptableObject
{
    public enum EIndent
    {
        Burn,    // ȭ��
        Freeze,  // ����
        Plague,  // ����
        Size,
    }

    public EIndent indent;
    public Sprite indentSprite;
    public string indentName;
    [Multiline(5)]
    public string indentExplanation;
    public bool isTurn;   // ���� �������� �����ϴ� indent����
    public bool isShowTurn;

    public static implicit operator IndentData(CharacterIndent v)
    {
        throw new NotImplementedException();
    }
}