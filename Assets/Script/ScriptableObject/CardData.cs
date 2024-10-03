using System.Collections;
using System.Collections.Generic;
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
    public string cardName;
    public CardType cardType;
    public int cost;
    public Sprite cardImage;
    public string cardDescription;
    public CardElement cardElement;

}