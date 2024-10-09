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
    public int Id; // 카드의 고유 ID
    public string CardName; // 카드 이름
    public CardType CardType; // 카드 타입
    public int Cost; // 카드 비용
    public Sprite CardImage; // 카드 이미지
    public string CardDescription; // 카드 설명
    public CardElement CardElement; // 카드 속성

    public void AssignId(int newId)
    {
        Id = newId; // ID 할당
    }
}