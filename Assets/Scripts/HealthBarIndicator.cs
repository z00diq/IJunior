using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarIndicator : HealthIndicator
{
    private Slider _slider;

    protected override void DisplayHealth(float value, float maxValue)
    {
        float normalizedValue = value / maxValue;
        _slider.value= normalizedValue;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
}
