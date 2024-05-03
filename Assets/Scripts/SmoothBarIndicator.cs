using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MyValueViewPckage
{
    [RequireComponent(typeof(Slider))]
    public class SmoothBarIndicator : Indicator
    {
        private Slider _slider;

        protected override void DisplayHealth(float value, float maxValue)
        {
            DisplayHealthAsync(value, maxValue);
        }

        private async void DisplayHealthAsync(float value, float maxValue)
        {
            float nextValue = value / maxValue;

            while (Mathf.Abs(_slider.value - nextValue)>0.0001f)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, nextValue, Time.deltaTime);
                await Task.Yield();
            }
        }

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
    }
}


