using UnityEngine;

[CreateAssetMenu(fileName = "MoverSetup", menuName = "Setups/Mover")]
public class MoverSetup : ScriptableObject
{
    [SerializeField] private float _maxRotationAngle;
    [SerializeField] private float _minRotationAngle;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;

    public float MaxRotationAngle => _maxRotationAngle;
    public float MinRotationAngle => _minRotationAngle;
    public float RotationSpeed =>_rotationSpeed;
    public float Speed => _speed;
    public float TapForce => _tapForce;
}