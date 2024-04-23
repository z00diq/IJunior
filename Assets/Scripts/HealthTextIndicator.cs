using Assets.Scripts;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HealthTextIndicator : HealthIndicator
{
    private TMP_Text _text;

    protected override void DisplayHealth(float value, float maxValue)
    {
        _text.text = $"{value}/{maxValue}";
    }

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();   
    }
}
