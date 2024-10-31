using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    static public EffectManager instance;

    public GameObject fire_Hit;
    public GameObject fire_Indent;
    public GameObject water_Hit;
    public GameObject water_Indent;
    public GameObject grass_Hit;
    public GameObject grass_Indent;
    public GameObject normal_Hit;
    public GameObject heal_1;
    public GameObject heal_2;
    private void Awake()
    {
        instance = this;
    }

    public GameObject GetEffect(CardData cardData)
    {
        switch(cardData.cardElement)
        {
            case CardElement.Fire:
                if (cardData.cardType == CardType.Attack)
                {
                    return fire_Hit;
                }
                else if (cardData.cardType == CardType.Defense)
                {
                    return fire_Indent;
                }
                else
                {
                    return heal_1;
                }
            case CardElement.Water:
                if (cardData.cardType == CardType.Attack)
                {
                    return water_Hit;
                }
                else if (cardData.cardType == CardType.Defense)
                {
                    return water_Indent;
                }
                else
                {
                    return heal_1;
                }
            case CardElement.Grass:
                if (cardData.cardType == CardType.Attack)
                {
                    return grass_Hit;
                }
                else if (cardData.cardType == CardType.Defense)
                {
                    return grass_Indent;
                }
                else
                {
                    return heal_1;
                }
            case CardElement.Common:
                if (cardData.cardType == CardType.Attack)
                {
                    return normal_Hit;
                }
                else if (cardData.cardType == CardType.Defense)
                {
                    return heal_2;
                }
                else
                {
                    return heal_1;
                }
            default :
                {
                    return normal_Hit;
                }
        }
    }
    
}
