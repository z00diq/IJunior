using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(PatrolMover))]
    internal class EnemyRoot : MonoBehaviour, IDamageable
    {
        [Header("Damage Settings")]
        [SerializeField] private float _damageValue;
        [SerializeField] private float _maxHealthValue;

        [Header("Pursurer Settings")]
        [SerializeField] private float _distanceToActivate;
        [SerializeField] private Transform _self;
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;

        private Health _health;
        private MoveSetSwithcher _moveSetSwithcher;
        public float Damage => _damageValue;

        private void Awake()
        {
            PatrolMover patrol = GetComponent<PatrolMover>();
            TargetPursuer pursuer = new TargetPursuer(_self,_target, _speed);

            _health = new Health(_maxHealthValue);
            _moveSetSwithcher = new MoveSetSwithcher(patrol, pursuer, _distanceToActivate, _self, _target);
        }

        private void Update()
        {
            _moveSetSwithcher.Update();
        }

        public void TakeDamage(float value)
        {
            _health.TakeDamage(value);

            if (_health.CurrentHealth == 0)
                Destroy(gameObject);
        }
    }
}