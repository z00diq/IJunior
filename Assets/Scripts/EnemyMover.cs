using System;
using UnityEngine;
internal class EnemyMover: MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Transform _target;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.LookAt(_target);
        transform.position=Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime* _speed);
    }

    internal void InitTarget(Transform target)
    {
        _target = target;
    }
}