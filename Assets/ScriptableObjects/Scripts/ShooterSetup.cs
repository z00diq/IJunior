using UnityEngine;

[CreateAssetMenu(fileName ="ShooterSetup", menuName ="Setups/Shooter")]
public class ShooterSetup : ScriptableObject
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Vector3 _shootDirection;

    public Bullet BulletPrefab =>_bulletPrefab;
    public float ReloadTime => _reloadTime;
    public float BulletSpeed => _bulletSpeed;
    public Vector3 ShootDirection => _shootDirection;
}