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

    internal void AddIndent(CharacterIndent characterIndent, int v)
    {
        throw new NotImplementedException();
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
                Debug.Log($"Applying {indentList[i].indentData.indentName} damage to {character.name}");
                // 매 턴마다 2의 피해를 주는 로직 추가
                character.Hit(2, null); // null은 공격자를 의미하지 않음
                Debug.Log("Burn");
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