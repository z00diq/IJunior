using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Vampirism
    {
        private const KeyCode s_spellButton = KeyCode.W;
        
        private Health _health;
        private BoxCollider2D _spellArea;
        
        private float _spellValue = 1f;
        private float _spellDistance = 3f;
        private float _ellapsedTime = 0f;
        private float _spellDuration = 6f;
        private float _spellReloadTime = 10;
        private float _reloadEllapsedTime = 0;
        
        private bool _spellIsReady = true;
        private bool _isCasting = false;

        public Vampirism(Health health, Transform position)
        {
            _health = health;
            _spellArea = position.gameObject.AddComponent<BoxCollider2D>();
            _spellArea.size = new Vector2(_spellDistance, _spellDistance);
            _spellArea.isTrigger = true;
        }

        public void Update()
        {
            if(Input.GetKeyDown(s_spellButton)) 
                if (_spellIsReady)
                    DrainLife();
            
            if(_isCasting == false)
                _reloadEllapsedTime += Time.deltaTime;

            if (_reloadEllapsedTime >= _spellReloadTime)
            {
                _reloadEllapsedTime = 0;
                _spellIsReady = true;
            }
        }

        private async void DrainLife()
        {
            _isCasting = true;
            _spellIsReady = false;

            while (_ellapsedTime < _spellDuration)
            {
                _ellapsedTime += Time.deltaTime;

                if (IsEnemyNear(out Health enemy))
                {
                    enemy.TakeDamage(_spellValue* Time.deltaTime);
                    _health.RestoreHealth(_spellValue* Time.deltaTime);
                }
      
                await Task.Yield();
            }

            _ellapsedTime = 0;
            _isCasting = false;
        }

        private bool IsEnemyNear(out Health enemyHealth)
        {
            enemyHealth = null;
            EnemyRoot enemy = null;

            ContactFilter2D filter = new ContactFilter2D();
            List<Collider2D> contacts = new();
            _spellArea.OverlapCollider(filter.NoFilter(), contacts);

            foreach (var contact in contacts)
            {
                if (contact.TryGetComponent(out enemy))
                {
                    enemyHealth = enemy.Health;
                    return true;
                }
            }

            return false;
        }
    }
}
