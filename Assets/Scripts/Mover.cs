using System;
using UnityEngine;
internal class Mover: MonoBehaviour
{
    private Vector3 _moveDirection;

    public void Initialize(Vector3 direction)
    {
        _moveDirection = direction;
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(_moveDirection.normalized*Time.deltaTime);
    }
}