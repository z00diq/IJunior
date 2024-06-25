using Assets.Scripts.UI;
using UnityEngine;

public class EntryPoint: MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _enemySpawnArea;
    [SerializeField] private StartGameScreen _startScreen;
    [SerializeField] private ReloadGameScreen _realoadScreen;
    [SerializeField] private EnemyDestoryer _enemyDestroyer;
    [SerializeField] private GameSetup _gameSetup;
    [SerializeField] private BirdTracker _birdTracker;

    private Game _game;

    private void Awake()
    {
        _game = new Game(_gameSetup, _spawnPoint, _enemySpawnArea, _enemyDestroyer, _birdTracker);
        _game.Initialize(_startScreen, _realoadScreen);
    }

    private void Update()
    {
        _game.Update();
    }
}