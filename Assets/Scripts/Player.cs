
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player: MonoBehaviour, IDamageable, IRestorable
    {
        [SerializeField] private float _maxHealthValue;
        [SerializeField] private float _damage;

        private Health _health;

        private void Awake()
        {
            _health = new Health(_maxHealthValue);
        }

        public void Heal(float value)
        {
            _health.RestoreHealth(value);
        }

        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);

            if (_health.CurrentHealth == 0)
                Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out Enemy enemy)) 
            {
                if ((transform.position - collision.transform.position).y >= 0.85f)
                {
                    if (enemy is IDamageable damageable)
                        damageable.TakeDamage(_damage);
                }
                else
                {
                    TakeDamage(enemy.Damage);
                }
            }

            if (collision.gameObject.TryGetComponent(out AidKit kit))
                Heal(kit.Value);
        }
    }
}
