using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private EnemyMover _spawnCreature;
        [SerializeField] private TargetMover[] _targets;

        public void Spawn()
        {
            var creature = Instantiate(_spawnCreature);

            creature.gameObject.transform.position = transform.position;
            creature.InitTarget(_targets[Random.Range(0,_targets.Length)].transform);
        }
    }
}
