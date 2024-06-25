using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bird : MonoBehaviour, IUpdatable, IStartable
{
    private const KeyCode ShootKey = KeyCode.A;

    [SerializeField] private Transform _bulletSpawnPoint;

    private BirdMover _birdMover;
    private BirdCollisionHandler _birdCollisionHandler;
    private Shooter _birdShooter;
    private InputRegistrator _inputRegistrator;
    private Vector3 _startPosition;
    private float _ellapsedTime = 0f;

    public BirdCollisionHandler CollisionHandler => _birdCollisionHandler;

    public void Initialize(BirdSetup birdSetup)
    {
        _startPosition = transform.position;
        _inputRegistrator = new InputRegistrator();
        _birdMover = new BirdMover(birdSetup.MoverSetup,GetComponent<Rigidbody2D>(), transform);
        _birdCollisionHandler = new BirdCollisionHandler();
        _birdShooter = new Shooter(birdSetup.ShooterSetup, _bulletSpawnPoint);
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void IStartable.Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void IUpdatable.Update()
    {
        _inputRegistrator.Update();

        if (Input.GetKeyDown(ShootKey))
        {
            if (_birdShooter.TryShoot(_ellapsedTime))
                _ellapsedTime = 0f;
        }

        _ellapsedTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, _birdMover.MinRotation, Time.deltaTime * _birdMover.RotationSpeed);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        if (_inputRegistrator.IsButtonPressed)
        {
            _birdMover.Move();
            _inputRegistrator.ResetInput();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _birdCollisionHandler.ProvideCollison(collision);
    }
}
