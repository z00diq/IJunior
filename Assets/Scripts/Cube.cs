using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject _explosionFX;

    private float _spawnChance = 100f;
    private float _minSpawnCount = 2;
    private float _maxSpawnCount = 4;
    private float _reduceModifier = 0.5f;

    public void OnCubeClick()
    {
        float spawnChance = Random.Range(0, 101);
        float count = Random.Range(_minSpawnCount, _maxSpawnCount);

        Instantiate(_explosionFX,transform.position,Quaternion.identity);

        if (spawnChance <= _spawnChance)
            for (int i = 0; i < count; i++)
                Instantiate();

        Destroy(gameObject);
    }

    private void Instantiate()
    {
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        newCube.transform.position = transform.position;
        Vector3 newScale = transform.localScale * _reduceModifier;
        newCube.transform.localScale = newScale;
        
        newCube.GetComponent<MeshRenderer>().material.color = CreateRandomColor();
        newCube.AddComponent<Rigidbody>();

        Cube cube = newCube.AddComponent<Cube>();
        cube._spawnChance = _spawnChance * _reduceModifier;
        cube._explosionFX = _explosionFX;
    }

    private Color CreateRandomColor()
    {
        float red = Random.Range(0f,1f);
        float green = Random.Range(0f, 1f); ;
        float blue = Random.Range(0f, 1f); ;

        return new Color(red,green,blue);
    }
}
