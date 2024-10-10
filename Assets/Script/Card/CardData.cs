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
    public int id; // 카드의 고유 ID
    public string cardName; // 카드 이름
    public CardType cardType; // 카드 타입
    public CardAttackArea cardAttackArea;
    public int cost; // 카드 비용
    public Sprite cardImage; // 카드 이미지
    public string cardDescription; // 카드 설명
    public CardElement cardElement; // 카드 속성

    public void AssignId(int newId)
    {
        id = newId; // ID 할당
    }
}