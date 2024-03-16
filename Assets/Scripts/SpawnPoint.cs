using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Mover _spawnCreature;
        [SerializeField] private TargetMover _target;

        public void Spawn()
        {
            var creature = Instantiate(_spawnCreature);

            creature.InitTarget(_target.transform);
        }
    }
}
