using System;
using UnityEngine;

public class Bullet:MonoBehaviour, IObstacle
{
    [SerializeField] private float _lifeTime;

    private Vector3 _moveDirection;
    private float _moveSpeed;

    private void Awake()
    {
        Destroy(gameObject, _lifeTime);
    }

    public void Initialize(Vector3 direction, float bulletSpeed)
    {
        _moveDirection = direction;
        _moveSpeed = bulletSpeed;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }
}