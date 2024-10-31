using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Merchandise : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _merchandiseText;
    [SerializeField]
    private Image _merchandiseImage;

    public void Init(string merchandiseText, Sprite merchandiseImage)
    {
        _merchandiseText.text = merchandiseText;
        _merchandiseImage.sprite = merchandiseImage;
    }
}
