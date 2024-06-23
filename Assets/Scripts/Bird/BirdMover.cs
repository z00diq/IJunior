using UnityEngine;

public class BirdMover
{
    private const KeyCode s_jumpKey = KeyCode.Space;

    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private MoverSetup _setup;

    public float RotationSpeed { get; private set; }
    public Quaternion MinRotation { get; private set; }
    public Quaternion MaxRotation { get; private set; }

    public BirdMover(MoverSetup setup,Rigidbody2D rigidbody2D, Transform transform)
    {
        _rigidbody2D = rigidbody2D;
        _transform = transform;
        _setup = setup;

        Quaternion maxRotation = Quaternion.Euler(0, 0, setup.MaxRotationAngle);
        Quaternion minRotation = Quaternion.Euler(0, 0, setup.MinRotationAngle);

        RotationSpeed = setup.RotationSpeed;
        MaxRotation = maxRotation;
        MinRotation = minRotation;
    }

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(_setup.Speed, _setup.TapForce);
        _transform.rotation = MaxRotation;
    }

}
