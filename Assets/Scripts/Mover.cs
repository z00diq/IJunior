using System;
using UnityEngine;
internal class Mover: MonoBehaviour
{
    private Transform _target;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.LookAt(_target);
        transform.position=Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime);
    }

    internal void InitTarget(Transform target)
    {
        _target = target;
    }
}