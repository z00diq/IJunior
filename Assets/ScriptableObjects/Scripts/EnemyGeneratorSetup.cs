using UnityEngine;

[CreateAssetMenu(fileName = "EnemyGeneratorSetup", menuName = "Setups/EnemyGenerator")]
public class EnemyGeneratorSetup : ScriptableObject
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private ShooterSetup _shooterSetup;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _minEnemyCount;
    [SerializeField] private int _maxEnemyCount;

    public Enemy Prefab => _prefab;
    public ShooterSetup ShooterSetup => _shooterSetup;
    public float SpawnTime => _spawnTime;
    public int MinEnemyCount => _minEnemyCount;
    public int MaxEnemyCount => _maxEnemyCount;


}