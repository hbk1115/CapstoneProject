using UnityEngine;

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
    None
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

    public void AssignId(int newId)
    {
        id = newId; // ID �Ҵ�
    }
}