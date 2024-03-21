using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(transform.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(-transform.forward);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(transform.right);
        }
        else if (Input.GetKey(KeyCode.A))
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
