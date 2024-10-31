using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CardType
{
    Attack,
    Defense,
    Resource
}

public enum CardElement
{
    Common,
    Water,
    Fire,
    Grass
}

public enum CardAttackArea
{
    Forward,
    Middle,
    Back,
    Random,
    All,
    MostHealth,
    LeastHealth,
    None,
    Player,
    Player_All
}

[CreateAssetMenu()]
public class CardData : ScriptableObject
{
    public int id; // ī���� ���� ID
    public string cardName; // ī�� �̸�
    public CardType cardType; // ī�� Ÿ��
    public CardAttackArea cardAttackArea;
    public int cost; // ī�� ���
    public Sprite cardImage; // ī�� �̹���
    public string cardDescription; // ī�� ����
    public CardElement cardElement; // ī�� �Ӽ�

    [Header("ī�� ��ġ")]
    public int attackPower;

    [Header("���ȿ��")]
    public List<UnityEvent> useEffect;

    public void AssignId(int newId)
    {
        id = newId; // ID �Ҵ�
    }
}