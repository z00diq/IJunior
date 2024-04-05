using UnityEngine;

namespace Assets.Scripts
{
    internal class EnemyRoot : MonoBehaviour,IDamageable
    {
        [SerializeField] private float _damageValue;
        [SerializeField] private float _maxHealthValue;

        private Health _health;

        public float Damage => _damageValue;

        private void Awake()
        {
            _health = new Health(_maxHealthValue);
        }

        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);

            if (_health.CurrentHealth == 0)
                Destroy(gameObject);
        }
    }
}