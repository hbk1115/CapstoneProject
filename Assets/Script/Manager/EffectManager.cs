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
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.fire_hit);
                    GameObject newEffect = Instantiate(fire_Indent);
                    return newEffect;
                }
                else if (cardData.cardType == CardType.Resource)
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.fire_indent);
                    GameObject newEffect = Instantiate(fire_Indent);
                    return newEffect;
                }
                else
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.heal_1);
                    GameObject newEffect = Instantiate(heal_1);
                    return newEffect;
                }
            case CardElement.Water:
                if (cardData.cardType == CardType.Attack)
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.ice_hit);
                    GameObject newEffect = Instantiate(water_Hit);
                    return newEffect;
                }
                else if (cardData.cardType == CardType.Resource)
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.ice_indent);
                    GameObject newEffect = Instantiate(water_Indent);
                    return newEffect;
                }
                else
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.heal_1);
                    GameObject newEffect = Instantiate(heal_1);
                    return newEffect;
                }
            case CardElement.Grass:
                if (cardData.cardType == CardType.Attack)
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.plague_hit);
                    GameObject newEffect = Instantiate(grass_Hit);
                    return newEffect;
                }
                else if (cardData.cardType == CardType.Resource)
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.plague_indent);
                    GameObject newEffect = Instantiate(grass_Indent);
                    return newEffect;
                }
                else
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.heal_1);
                    GameObject newEffect = Instantiate(heal_1);
                    return newEffect;
                }
            case CardElement.Common:
                if (cardData.cardType == CardType.Attack)
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.normal_hit);
                    GameObject newEffect = Instantiate(normal_Hit);
                    return newEffect;
                }
                else if (cardData.cardType == CardType.Defense)
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.heal_2);
                    GameObject newEffect = Instantiate(heal_2);
                    return newEffect;
                }
                else
                {
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.heal_1);
                    GameObject newEffect = Instantiate(heal_1);
                    return newEffect;
                }
            default :
                {
                    GameObject newEffect = Instantiate(heal_1);
                    return newEffect;
                }
        }
    }
    
}
