using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // 상태 이상 배열 추가
    public bool[] indent = new bool[(int)IndentData.EIndent.Size];

    public abstract void Dead();
    public abstract void Hit(int damage, Character attacker);
    public abstract void Act();
}