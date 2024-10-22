using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _rewardText;
    [SerializeField]
    private Image _rewardImage;

    public void Init(string rewardText, Sprite rewardImage)
    {
        _rewardText.text = rewardText;
        _rewardImage.sprite = rewardImage;
    }
}
