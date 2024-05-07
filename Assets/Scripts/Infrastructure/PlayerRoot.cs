using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _prefab;

    private Mover _mover;

    public void Instantiate()
    {
        GameObject plaayr =  Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
        var rrg = plaayr.AddComponent<Rigidbody>();
        _mover = new Mover(rrg);
    }

    private void Update()
    {
        _mover.GetPosition();
    }
}
