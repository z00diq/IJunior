using UnityEngine;

namespace MyValueViewPckage
{
    public class Indicator : MonoBehaviour
    {
        private IValueChanging _valueContainer;

        public void Construct(IValueChanging continer)
        {
            _valueContainer = continer;
            _valueContainer.ValueChanged += DisplayHealth;
        }

        public void Deconstruct()
        {
            _valueContainer.ValueChanged -= DisplayHealth;
        }

        protected virtual void DisplayHealth(float value, float maxValue)
        {

        }
    }
}
