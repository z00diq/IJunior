using System;
using UnityEngine;

public class Bullet:MonoBehaviour, IObstacle
{
    private Vector3 _moveDirection;
    private float _moveSpeed;

    private void Awake()
    {
        Destroy(gameObject,5f);
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