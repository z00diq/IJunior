using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private PlayerRoot _playerRoot;

    private void Awake()
    {
        _playerRoot.Instantiate();
    }
}

public class Mover
{
    private Rigidbody _rigidbody;

    public Mover(Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
        _rigidbody.velocity = Vector2.down;
    }

    public void GetPosition()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.one*2,ForceMode.Impulse);
        }
    }
}