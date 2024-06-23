using UnityEngine;

[CreateAssetMenu(fileName = "GameSetup", menuName = "Setups/Game")]
public class GameSetup:ScriptableObject
{
    [SerializeField] private BirdSetup _birdSetup;
    [SerializeField] private EnemyGeneratorSetup _enemyGeneratorSetup;

    public BirdSetup BirdSetup => _birdSetup;
    public EnemyGeneratorSetup EnemyGeneratorSetup => _enemyGeneratorSetup;

    public Vector3 StartPosition { get; internal set; }
}