using UnityEngine;

public class CoinSpawner: MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        foreach (Transform spawnPoint in _spawnPoints)
        {
            Instantiate(_prefab, spawnPoint.position, Quaternion.identity);
        }
    }
}

