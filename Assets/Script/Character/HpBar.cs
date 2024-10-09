using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Slider hpBarSlider;
    [SerializeField] private TextMeshProUGUI hpBarText;
    [SerializeField] private Image hpBarFill;

    [SerializeField] private Color originColor;
    [SerializeField] private Color shieldColor;

    private RectTransform hpBarSliderRectTransform;

    private void Awake()
    {
        hpBarSliderRectTransform = hpBarSlider.GetComponent<RectTransform>();
    }

    public void DisplayHpBar(int currentHp, int maxHp)
    {
        hpBarSlider.value = (float)currentHp / maxHp;
        hpBarText.text = currentHp + "/" + maxHp;
    }
}
