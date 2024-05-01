using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Vampirism
    {
        private const KeyCode s_spellButton = KeyCode.W;
        
        private Health _health;
        private float _spellValue = 10f;
        private float _spellDistance = 2f;
        private float _ellapsedTime = 0f;
        private float _spellDuration = 6f;
        private bool _spellIsReady = true;
        private Transform _position;

        public Vampirism(Health health, Transform position)
        {
            _health = health;
            _position = position;
        }

        public void Update()
        {
            if(Input.GetKeyDown(s_spellButton)) 
                if (_spellIsReady)
                    DrainLife();
        }

        private async void DrainLife()
        {
            if (IsEnemyNear(out Health enemy) == false)
                return;

            _spellIsReady = false;

            while (_ellapsedTime< _spellDuration)
            {
                _ellapsedTime += Time.deltaTime;
                enemy.TakeDamage(_spellValue);
                _health.RestoreHealth(_spellValue);

                await Task.Yield();
            }

            _spellIsReady = true;
        }

        private bool IsEnemyNear(out Health enemyHealth)
        {
            enemyHealth = null;
            EnemyRoot enemy = null;
            RaycastHit2D hitInfo = Physics2D.Raycast(_position.position, Vector3.right,5);

            if (hitInfo.collider?.TryGetComponent(out enemy) == true)
            {
                enemyHealth = enemy.Health;
                return true;
            }

            return false;
        }
    }
}
