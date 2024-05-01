
using MyValueViewPckage;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerRoot: MonoBehaviour, IDamageable
    {
        [SerializeField] private float _maxHealthValue;
        [SerializeField] private float _damage;
        [SerializeField] private float _applayingDamageModifier = 0.8f;
        [SerializeField] private Indicator _healthBar;

        private Health _health;
        private Vampirism _vampirism;

        private void Awake()
        {
            _health = new Health(_maxHealthValue);
            _vampirism = new Vampirism(_health, transform);
            _healthBar.Construct(_health);
        }

        private void Update()
        {
            _vampirism.Update();
        }

        private void OnDisable()
        {
            _healthBar.Deconstruct();
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
                    TakeDamage(enemy.Damage);
                }
            }

            if (collision.gameObject.TryGetComponent(out AidKit kit))
            {
                Destroy(kit.gameObject);
                _health.RestoreHealth(kit.Value);
            }
        }

        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);

            if (_health.CurrentHealth == 0)
                Destroy(gameObject);
        }
    }
}
