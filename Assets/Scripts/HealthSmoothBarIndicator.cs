using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSmoothBarIndicator : HealthIndicator
{
    private Slider _slider;
 
    protected override void DisplayHealth(float value,float maxValue)
    {
        DisplayHealthAsync(value,maxValue);
    }

    private async void DisplayHealthAsync(float value,float maxValue)
    {
        float nextValue = value / maxValue;
        
        while (_slider.value!=nextValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, nextValue,Time.deltaTime);
            await Task.Yield();
        }
    } 

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
}
