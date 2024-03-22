using UnityEngine;

public class Mover : MonoBehaviour
{
    private const KeyCode MoveForward = KeyCode.W;
    private const KeyCode MoveBack = KeyCode.S;
    private const KeyCode MoveRight = KeyCode.D;
    private const KeyCode MoveLeft = KeyCode.A;

    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(MoveForward))
        {
            Move(transform.forward);
        }
        else if (Input.GetKey(MoveBack))
        {
            Move(-transform.forward);
        }

        if (Input.GetKey(MoveRight))
        {
            Move(transform.right);
        }
        else if (Input.GetKey(MoveLeft))
        {
            Move(-transform.right);
        }
    }

    private void Move(Vector3 normilizedDirection)
    {
        float moveDistance = Time.deltaTime * _speed;
        normilizedDirection = normilizedDirection.normalized;
        transform.Translate(normilizedDirection * moveDistance);
    }
}
