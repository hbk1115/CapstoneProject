using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndentObject : MonoBehaviour
{
    public IndentData indentData; // 상태 이상 데이터
    public int turn;               // 남은 턴

    public void Init(IndentData data, int value)
    {
        indentData = data;
        turn = value;
    }

    public void AddTurn(int value)
    {
        turn += value;
    }

    public void UpdateIndent()
    {
        // 상태 이상의 시각적 업데이트 로직
      
    }
}