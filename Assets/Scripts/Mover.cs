using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    
    private const KeyCode MoveRight = KeyCode.D;
    private const KeyCode MoveLeft = KeyCode.A;

    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;

    private bool isMoving = false;

    private void Update()
    {
        isMoving = false;
        _animator.SetBool(nameof(isMoving), isMoving);

        if (Input.GetKey(MoveRight))
        {
            Move(transform.right);
        }
        else if (Input.GetKey(MoveLeft))
        {
            _renderer.flipX = true;
            Move(-transform.right);
        }
    }

    private void Move(Vector3 normilizedDirection)
    {
        isMoving = true;
        float moveDistance = Time.deltaTime * _speed;
        normilizedDirection = normilizedDirection.normalized;
        _animator.SetBool(nameof(isMoving),isMoving);
        transform.Translate(normilizedDirection * moveDistance);
    }
}
