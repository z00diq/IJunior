
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class HealthIndicator : MonoBehaviour
    {
        private Health _health;

        public void Decompile()
        {
            _health.ValueChanged -= DisplayHealth;
        }

        public void Initialize(Health health)
        {
            _health = health;
            _health.ValueChanged += DisplayHealth;
        }

        protected virtual void DisplayHealth(float value, float maxValue)
        {

        }
    }
}
