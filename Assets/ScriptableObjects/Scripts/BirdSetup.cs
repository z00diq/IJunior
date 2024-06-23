using UnityEngine;

[CreateAssetMenu(fileName = "BirdSetup", menuName = "Setups/Bird")]
public class BirdSetup : ScriptableObject
{
    [SerializeField] private Bird _prefab;
    [SerializeField] private ShooterSetup _shoot;
    [SerializeField] private MoverSetup _move;

    public Bird Prefab => _prefab;
    public ShooterSetup ShooterSetup => _shoot;
    public MoverSetup MoverSetup => _move;
}