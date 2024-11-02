using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndentObject : MonoBehaviour
{
    public IndentData indentData; // 상태 이상 데이터
    public int turn;               // 남은 턴

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
        // 상태 이상의 시각적 업데이트 로직
      
    }
}