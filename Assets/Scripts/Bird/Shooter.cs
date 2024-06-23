using System.Threading.Tasks;
using UnityEngine;
public class Shooter
{
    private Bullet _prefab;
    
    private float _reloadTime;
    private float _bulletSpeed;
    private Vector3 _shootDirection;
    private Transform _spawnPoint;
  
    public Shooter(ShooterSetup setup, Transform spawnPoint)
    {
        _prefab = setup.BulletPrefab;
        _spawnPoint = spawnPoint;
        _reloadTime = setup.ReloadTime;
        _bulletSpeed = setup.BulletSpeed;
        _shootDirection = setup.ShootDirection;
    }

    public bool TryShoot(float ellapsedTime)
    {
        if (ellapsedTime < _reloadTime)
            return false;

        Shoot();
        return true;
    }

    private void Shoot()
    {
        Bullet bullet = Object.Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
        bullet.Initialize(_shootDirection, _bulletSpeed);
    }
}