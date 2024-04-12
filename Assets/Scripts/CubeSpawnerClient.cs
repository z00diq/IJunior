using Assets.Scripts;
using UnityEngine;

public class CubeSpawnerClient : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] private int _spawnCount;
    
    private CubeSpawnConfiguration _configure;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray,out RaycastHit hit);

            if (hit.collider == null)
                return;

            if (hit.collider.TryGetComponent(out CubeRoot cube))
            {
                _configure = cube.Configuration;
                int chance = Random.Range(1, 100);

                if (chance <= _configure.SpawnChance)
                    Create(cube);

                cube.Explode();
            }
        }
    }

    private void Create(CubeRoot cube)
    {
        int count = Random.Range(1, _configure.SpawnCount);

        for (int i = 0; i < count; i++)
            cube.Instantiate();
    }
}
