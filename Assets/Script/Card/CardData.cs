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
    public int id; // 카드의 고유 ID
    public string cardName;
    public CardType cardType;
    public int cost;
    public Sprite cardImage;
    public string cardDescription;
    public CardElement cardElement;

    public void AssignId(int newId)
    {
        id = newId;
    }
}