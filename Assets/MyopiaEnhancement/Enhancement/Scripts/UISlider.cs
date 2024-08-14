using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UISlider : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI sliderText = null;
    [SerializeField] private float maxSliderAmount = 6.0f;
    [SerializeField] private float minSliderAmount = 0.0f;
    [SerializeField] private Slider slider;


    public void SliderChange(float value)
    {
        float new_value = value + 3;
        float percentage = (new_value * 100);
        float localValue = percentage / maxSliderAmount;
        sliderText.text = localValue.ToString("0.00");
    }
}
