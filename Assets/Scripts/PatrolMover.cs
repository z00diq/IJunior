using UnityEngine;
using System.Collections;
using System;

public class PatrolMover : MonoBehaviour
{
    [SerializeField] private Transform[] _pathPoints;
    [SerializeField] private float _speed = 10;

    private int _index = 0;
    private bool isMove = true;

    private void OnEnable()
    {
        isMove = true;
        StartCoroutine(nameof(Patrol));
    }

    private void OnDisable()
    {
        isMove = false;
        StopCoroutine(nameof(Patrol));
    }

    private IEnumerator Patrol()
    {
        while (isMove)
        {
            while (Math.Abs(transform.position.x - _pathPoints[_index].position.x)>0.01f)
            {
                Vector3 newPosition = Vector2.MoveTowards(transform.position, _pathPoints[_index].position, Time.deltaTime * _speed);
                newPosition.y = transform.position.y;
                newPosition.z = transform.position.z;
                transform.position = newPosition;
                yield return null;
            }

            _index = ++_index % _pathPoints.Length;
        }
    }
}

