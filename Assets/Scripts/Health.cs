using System;

namespace Assets.Scripts
{
    public class Health
    {
        private float _maxValue;
        private float _value;

        public event Action<float,float> ValueChanged;

        public float CurrentHealth => _value;

        public  Health(float maxValue)
        {
            _maxValue = maxValue;
            _value = _maxValue;
        }

        public void Initialize()
        {
            ValueChanged?.Invoke(_value, _maxValue);
        }

        public void TakeDamage(float value)
        {
            _value = Math.Clamp(_value - value, 0, _maxValue);
            ValueChanged?.Invoke(_value, _maxValue);
        }

        public void RestoreHealth(float value)
        {
            _value = Math.Clamp(_value + value, 0, _maxValue);
            ValueChanged?.Invoke(_value, _maxValue);
        }
    }
}
