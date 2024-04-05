
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerRoot: MonoBehaviour, IDamageable
    {
        [SerializeField] private float _maxHealthValue;
        [SerializeField] private float _damage;
        [SerializeField] private float _applayingDamageModifier = 0.8f;

        private Health _health;

        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);
        }

        private void Awake()
        {
            _health = new Health(_maxHealthValue);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out EnemyRoot enemy))
            {
                Vector2 substract =  (Vector2)transform.position- (Vector2)enemy.transform.position;
                
                if (substract.y > enemy.transform.localScale.y * _applayingDamageModifier)
                    (enemy as IDamageable).TakeDamage(_damage);
                else 
                {
                    Debug.Log("a");
                    TakeDamage(enemy.Damage);
                }
            }
        }
    }
}
