using UnityEngine;

public class Mover : MonoBehaviour
{
    private const KeyCode MoveRight = KeyCode.RightArrow;
    private const KeyCode MoveLeft = KeyCode.LeftArrow;
    private Quaternion _leftRotation = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion _rightRotation = Quaternion.Euler(0f, 0f, 0f);


    [SerializeField] private float _speed;
    [SerializeField] private Transform _renderer;
    [SerializeField] private Animator _animator;

    private bool isMoving = false;

    private void Update()
    {
        isMoving = false;
        _animator.SetBool(nameof(isMoving), isMoving);

        if (Input.GetKey(MoveRight))
        {
            _renderer.rotation = _rightRotation;
            Move(transform.right);
        }
        else if (Input.GetKey(MoveLeft))
        {
            _renderer.rotation = _leftRotation;
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
