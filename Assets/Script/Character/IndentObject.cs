using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndentObject : MonoBehaviour
{
    public IndentData indentData; // ���� �̻� ������
    public int turn;               // ���� ��

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
        // ���� �̻��� �ð��� ������Ʈ ����
      
    }
}