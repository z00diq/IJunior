using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bird : MonoBehaviour, IUpdatable
{
    private const KeyCode s_jumpKey = KeyCode.Space;
    private const KeyCode s_shootKey = KeyCode.A;

    [SerializeField] private Transform _bulletSpawnPoint;

    private Animator _animator;
    private BirdMover _birdMover;
    private BirdCollisionHandler _birdCollisionHandler;
    private Shooter _birdShooter;
    private Vector3 _startPosition;

    private float _ellapsedTime = 0f;

    public BirdCollisionHandler CollisionHandler => _birdCollisionHandler;

    public void Initialize(BirdSetup birdSetup)
    {
        _startPosition = transform.position;
        _animator = GetComponent<Animator>();
        _birdMover = new BirdMover(birdSetup.MoverSetup,GetComponent<Rigidbody2D>(), transform);
        _birdCollisionHandler = new BirdCollisionHandler();
        _birdShooter = new Shooter(birdSetup.ShooterSetup, _bulletSpawnPoint);
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _birdCollisionHandler.ProvideCollison(collision);
    }

    void IUpdatable.Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void IUpdatable.Update()
    {
        if (Input.GetKeyDown(s_jumpKey))
            _birdMover.Move();

        if (Input.GetKeyDown(s_shootKey))
        {
            if (_birdShooter.TryShoot(_ellapsedTime))
                _ellapsedTime = 0f;
        }

        _ellapsedTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, _birdMover.MinRotation, Time.deltaTime * _birdMover.RotationSpeed);
    }
}
