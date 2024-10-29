using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIndent : MonoBehaviour
{
    private Character character;

    [SerializeField] private Transform indentParent;
    [SerializeField] private IndentObject indentPrefab;

    private List<IndentObject> indentList = new List<IndentObject>();

    public void Init(Character character)
    {
        this.character = character;
    }

    public void ClearIndentList()
    {
        while (indentList.Count != 0)
        {
            Destroy(indentList[0].gameObject);
            indentList.RemoveAt(0);
        }
        indentList = new List<IndentObject>();
    }

    public void AddIndent(IndentData indentData, int value)
    {
        character.indent[(int)indentData.indent] = true;

        Debug.Log($"Adding {indentData.indentName} to {character.name} for {value} turns");

        for (int i = 0; i < indentList.Count; i++)
        {
            if (indentList[i].indentData == indentData)
            {
                indentList[i].AddTurn(value);
                Visualize();
                return;
            }
        }

        indentList.Add(Instantiate(indentPrefab, indentParent));
        indentList[indentList.Count - 1].Init(indentData, value);

        Visualize();
    }

    public void Visualize()
    {
        for (int i = 0; i < indentList.Count; i++)
        {
            indentList[i].UpdateIndent();
        }
    }

    public void UpdateIndents()
    {
        List<IndentObject> list = new List<IndentObject>();

        for (int i = 0; i < indentList.Count; i++)
        {
            if (indentList[i].indentData.isTurn)
            {
                Debug.Log($"Applying {indentList[i].indentData.indentName} effect to {character.name}");

                // 화상 효과 처리
                if (indentList[i].indentData.indent == IndentData.EIndent.Burn)
                {
                    character.Hit(2, null);
                    Debug.Log("Burn damage applied");
                }

                // 동상 효과 처리
                if (indentList[i].indentData.indent == IndentData.EIndent.Freeze)
                {
                    Debug.Log("Freeze effect active, no damage applied");
                }

                // 역병 효과 처리
                if (indentList[i].indentData.indent == IndentData.EIndent.Plague)
                {
                    // 피해를 주지 않음, 대신 다른 효과를 처리하거나 상태 변경을 진행할 수 있음
                    Debug.Log("Plague effect active, damage handled in attack method.");
                }

                indentList[i].turn--;
            }
        }

        for (int i = 0; i < indentList.Count; i++)
        {
            if (indentList[i].indentData.isTurn && indentList[i].turn <= 0)
            {
                character.indent[(int)indentList[i].indentData.indent] = false;
                list.Add(indentList[i]);
            }
        }

        while (list.Count > 0)
        {
            IndentObject temp = list[0];
            indentList.Remove(temp);
            list.Remove(temp);
            Destroy(temp.gameObject);
        }

        Visualize();
    }

    public void RemoveIndent(IndentData.EIndent indentType)
    {
        for (int i = 0; i < indentList.Count; i++)
        {
            if (indentList[i].indentData.indent == indentType)
            {
                IndentObject temp = indentList[i];
                indentList.Remove(temp);
                Destroy(temp.gameObject);
            }
        }
    }
}