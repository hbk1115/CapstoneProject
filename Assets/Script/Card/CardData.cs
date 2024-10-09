using UnityEngine;

public enum CardType
{
    Attack,
    Defense,
    Resource
}

public enum CardElement
{
    Light,
    Dark,
    Water,
    Fire,
    Grass
}

[CreateAssetMenu()]
public class CardData : ScriptableObject
{
    public int Id; // ī���� ���� ID
    public string CardName; // ī�� �̸�
    public CardType CardType; // ī�� Ÿ��
    public int Cost; // ī�� ���
    public Sprite CardImage; // ī�� �̹���
    public string CardDescription; // ī�� ����
    public CardElement CardElement; // ī�� �Ӽ�

    public void AssignId(int newId)
    {
        Id = newId; // ID �Ҵ�
    }
}