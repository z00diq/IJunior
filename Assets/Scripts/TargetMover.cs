﻿using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

namespace Assets.Scripts
{
    public class TargetMover:MonoBehaviour
    {
        [SerializeField] private Transform[] _pathPoints;
        [SerializeField] private float _speed = 10;

        private int _index = 0;
        private bool isMove = true;

        private void OnEnable()
        {
            isMove = true;
        }

        private void OnDisable()
        {
            isMove = false;
        }

        private void Start()
        {
            StartCoroutine(nameof(Patrol));
        }

        private IEnumerator Patrol()
        {
            while (isMove)
            {
                transform.LookAt(_pathPoints[_index]);

                while(transform.position!= _pathPoints[_index].position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _pathPoints[_index].position, Time.deltaTime*_speed);
                    yield return null;
                }
          
                _index++;

                if (_index == _pathPoints.Length)
                    _index = 0;
            }
        }
    }
}