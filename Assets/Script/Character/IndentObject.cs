using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndentObject : MonoBehaviour
{
    public IndentData indentData; // ���� �̻� ������
    public int turn;               // ���� ��

    public Image myImage;
    [SerializeField]
    private List<Sprite> sprites;

    public void Init(IndentData data, int value)
    {
        indentData = data;
        turn = value;

        if(indentData.indent == IndentData.EIndent.Burn)
        {
            myImage.sprite = sprites[0];
        }
        else if (indentData.indent == IndentData.EIndent.Freeze)
        {
            myImage.sprite = sprites[1];
        }
        else if (indentData.indent == IndentData.EIndent.Plague)
        {
            myImage.sprite = sprites[2];
        }
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