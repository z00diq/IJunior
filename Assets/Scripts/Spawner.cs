using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTime;

    private float _elapsedTime=0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _spawnTime)
        {
            Spawn();
            _elapsedTime = 0;
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
