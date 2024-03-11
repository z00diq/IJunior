using System;
using UnityEngine;

public class SphereMover : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    private Vector3 _startPosition;
    private Vector3 _target;

    private void Start()
    {
        _startPosition = transform.position;
        _target = _endPoint.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime);

        if (transform.position == _endPoint.position)
            _target = _startPosition;

        if (transform.position == _startPosition)
            _target = _endPoint.position;
    }
}
