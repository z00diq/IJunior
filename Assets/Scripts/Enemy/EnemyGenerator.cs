using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

public class EnemyGenerator: IUpdatable
{
    private ObjectPool<Enemy> _enemies;
    private EnemyGeneratorSetup _generatorSetup;
    private EnemyDestoryer _destoryer;

    private float _minPosX;
    private float _minPosY;
    private float _maxPosX;
    private float _maxPosY;
    private float _ellapsedTime = 0f;

    private Transform _spawnArea;

    public EnemyGenerator(EnemyGeneratorSetup generatorSetup, Transform spawnArea, EnemyDestoryer enemyDestoryer)
    {
        _generatorSetup = generatorSetup;
        _spawnArea = spawnArea;
        _destoryer = enemyDestoryer;
        _enemies = new ObjectPool<Enemy>
           (
               CreateEnemy,
               TakeEnemyFromPool,
               ReturnToPool,
               (Enemy instance) => Object.Destroy(instance.gameObject),
               true,
  generatorSetup.MinEnemyCount,
               generatorSetup.MaxEnemyCount
           );

        _destoryer.EnemyTriggered += _enemies.Release;
    }

    public void Start()
    {
        _minPosX = _spawnArea.position.x - _spawnArea.localScale.x / 2 
            + _generatorSetup.Prefab.transform.localScale.x / 2;

        _maxPosX = _spawnArea.position.x + _spawnArea.localScale.x / 2 
            - _generatorSetup.Prefab.transform.localScale.x / 2;

        _minPosY = _spawnArea.position.y - _spawnArea.localScale.y / 2 
            + _generatorSetup.Prefab.transform.localScale.y / 2;

        _maxPosY = _spawnArea.position.y + _spawnArea.localScale.y / 2 
            - _generatorSetup.Prefab.transform.localScale.y / 2;
    }

    public void Update()
    {
        _ellapsedTime += Time.deltaTime;

        if (_ellapsedTime >= _generatorSetup.SpawnTime)
        {
            _enemies.Get();
            _ellapsedTime = 0f;
        }
    }

    private Enemy CreateEnemy()
    {
        Vector3 spawnPosition = CalculateSpawnPosition();
        Enemy enemy = Object.Instantiate(_generatorSetup.Prefab, spawnPosition, _generatorSetup.Prefab.transform.rotation);

        enemy.Initialize(_generatorSetup.ShooterSetup);

        return enemy;
    }

    private void TakeEnemyFromPool(Enemy instance)
      {
        instance.gameObject.SetActive(true);
    }

    private void ReturnToPool(Enemy instance)
    {
        instance.gameObject.SetActive(false);
        instance.transform.position = CalculateSpawnPosition();
    }

    private Vector3 CalculateSpawnPosition()
    {
        float posX = Random.Range(_minPosX+_spawnArea.position.x, _maxPosX+_spawnArea.position.x);
        float posY = Random.Range(_minPosY + _spawnArea.position.y, _maxPosY + _spawnArea.position.y);
        Vector3 spawnPosition = new Vector3(posX, posY, 0f);
        return spawnPosition;
    }

    internal void Reset()
    {
        _enemies.Clear();
    }

    ~EnemyGenerator()
    {
        _destoryer.EnemyTriggered -= _enemies.Release;
    }
}

