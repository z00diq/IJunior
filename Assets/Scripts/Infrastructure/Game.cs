using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Game : IUpdatable
{
    private Bird _bird;
    private EnemyGenerator _enemyGenerator;
    private List<IUpdatable> _updatables;
    private BirdTracker _birdTracker;
    private bool isPlaying = false;
    private StartGameScreen _startScreen;
    private ReloadGameScreen _reloadScreen;

    public Game(GameSetup setup, Transform birdSpawnPoint, Transform enemySpawnArea, EnemyDestoryer enemyDestoryer, BirdTracker birdTracker)
    {
        BirdSetup birdSetup = setup.BirdSetup;
        EnemyGeneratorSetup generatorSetup = setup.EnemyGeneratorSetup;
        _birdTracker = birdTracker;
        _updatables = new List<IUpdatable>();
        _bird = Bird.Instantiate(birdSetup.Prefab, birdSpawnPoint.position, Quaternion.identity);
        _bird.Initialize(birdSetup);
        _enemyGenerator = new EnemyGenerator(generatorSetup, enemySpawnArea,enemyDestoryer);
        _updatables.Add(_bird);
        _updatables.Add(_enemyGenerator);
    }

    public Bird Bird=>_bird;
    public EnemyGenerator EnemyGenerator => _enemyGenerator;

    public void Initialize(StartGameScreen startScreen, ReloadGameScreen realoadScreen)
    {
        _startScreen = startScreen;
        _reloadScreen = realoadScreen;

        _startScreen.StartButtonClick += Start;
        _reloadScreen.RestartButtonClick += Reset;
    }

    public void Start()
    {
        foreach (IUpdatable item in _updatables)
        {
            item.Start();
        }

        _bird.CollisionHandler.CollisionDetected += OnCollisionDetected;
        _birdTracker.Initialize(_bird);
        _birdTracker.enabled = true;

        isPlaying = true;
    }

    public void Update()
    {
        if (isPlaying == false)
            return;

        foreach (IUpdatable item in _updatables)
        {
            item.Update();
        }
    }

    private void OnCollisionDetected(IObstacle interactable)
    {
        Time.timeScale = 0;
        _reloadScreen.Open();
    }

    private void Reset()
    {
        _bird.Reset();
        _enemyGenerator.Reset();
        _reloadScreen.Close();
        Time.timeScale = 1;
    }

    ~Game()
    {
        _bird.CollisionHandler.CollisionDetected -= OnCollisionDetected;
    }
}
