using UnityEngine;

public class Enemy : MonoBehaviour, IObstacle
{
    [SerializeField] private Transform _bulletSpawnpoint;

    private ShooterSetup _setup;
    private Shooter _shooter;
    private float _elapsedTime=0f;

    public void Initialize(ShooterSetup setup)
    {
        _shooter = new Shooter(setup, _bulletSpawnpoint);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_shooter.TryShoot(_elapsedTime))
            _elapsedTime = 0f;
    }
}