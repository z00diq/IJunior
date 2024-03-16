using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnTime;

    private bool _isContinueSpawn;

    private void OnEnable()
    {
        _isContinueSpawn = true;
    }

    private void OnDisable()
    {
        _isContinueSpawn = false;
    }

    private void Start()
    {
        StartCoroutine(nameof(SpawnUntil));
    }

    private IEnumerator SpawnUntil()
    {
        var timer = new WaitForSecondsRealtime(_spawnTime);

        while (_isContinueSpawn)
        {
            Spawn();
            yield return timer;       
        }
    }

    private void Spawn()
    {
        int pointIndex = Random.Range(0, _spawnPoints.Length);
        _spawnPoints[pointIndex].Spawn();
    }
}