
using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class CubeSpawnConfiguration
    {
        [SerializeField][Range(1,10)] private int _spawnCount;

        [SerializeField] private Vector3 _scale = Vector3.one;
        [SerializeField] private float _reduceModificator = .5f;
        [SerializeField] private float _spawnChance = 100f;

        public int SpawnCount => _spawnCount;
        public float SpawnChance => _spawnChance;
        public Vector3 Scale => _scale;

        public CubeSpawnConfiguration(float spawnChance, Vector3 scale, int spawnCount)
        {
            _spawnChance = spawnChance;
            _scale = scale;
            _spawnCount = spawnCount;
        }

        public CubeSpawnConfiguration RecalculateConfiguration()
        {
            return new CubeSpawnConfiguration(_spawnChance * _reduceModificator, _scale * _reduceModificator, _spawnCount);
        }
    }
}
