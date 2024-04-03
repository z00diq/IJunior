using UnityEngine;
using UnityEngine.Tilemaps;

public class Jumper : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;
    
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _jumpImpulse = 2;
    [SerializeField] private Animator _animator;

    private bool isGrounded;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey) && isGrounded)
            Jump();
    }

    private void Jump()
    {
        _animator.SetTrigger(nameof(Jump));
        _rigidBody.AddForce(transform.up * _jumpImpulse, ForceMode2D.Impulse);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider is CompositeCollider2D) 
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider is CompositeCollider2D)
            isGrounded = false;
    }
}

