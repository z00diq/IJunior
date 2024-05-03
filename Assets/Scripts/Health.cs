﻿using MyValueViewPckage;
using System;

namespace Assets.Scripts
{
    public class Health:IValueChanging
    {
        private float _maxValue;
        private float _value;

        public event Action<float, float> ValueChanged;
        public event Action Dieing;

        public float CurrentHealth => _value;

        public  Health(float maxValue)
        {
            _maxValue = maxValue;
            _value = _maxValue;
        }

        public void TakeDamage(float value)
        {
            _value = Math.Clamp(_value - value, 0, _maxValue);
            ValueChanged?.Invoke(_value, _maxValue);

            if (_value == 0)
                Dieing?.Invoke();
        }

        public void RestoreHealth(float value)
        {
            _value = Math.Clamp(_value + value, 0, _maxValue);
            ValueChanged?.Invoke(_value, _maxValue);
        }
    }
}
