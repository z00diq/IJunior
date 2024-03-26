using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jumper : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;
    
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _jumpImpulse = 2;
    [SerializeField] private Animator _animator;

    private float isGroundedDistance = 0.1f;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey) && IsGrounded())
            Jump();
    }

    private void Jump()
    {
        _animator.SetTrigger(nameof(Jump));
        _rigidBody.AddForce(transform.up * _jumpImpulse, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        Ray2D ray = new Ray2D(transform.position,Vector2.down);
        var result = Physics2D.Raycast(ray.origin, ray.direction);
        
        return result.distance< isGroundedDistance;
    }
}

