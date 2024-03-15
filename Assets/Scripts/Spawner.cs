using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Transform[] _spawnPoints;
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
        var spawnedObject = Create(pointIndex);
        spawnedObject.GetComponent<Mover>();
    }

    private GameObject Create(int pointIndex)
    {
        GameObject creature = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        creature.transform.position = _spawnPoints[pointIndex].position;
        creature.AddComponent<Mover>().Initialize(_direction);
        return creature;
    }
}