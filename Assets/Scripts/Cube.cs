using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject _explosionFX;

    private float _spawnChance = 100f;
    private float _minSpawnCount = 2;
    private float _maxSpawnCount = 4;
    private float _reduceModifier = 0.5f;
    private Color _color;

    public void OnCubeClick()
    {
        float spawnChance = Random.Range(0, 101);
        float count = Random.Range(_minSpawnCount, _maxSpawnCount);
        _color = CreateRandomColor();
        if (spawnChance <= _spawnChance)
            for (int i = 0; i < count; i++)
                Instantiate();

        Destroy(gameObject);
    }

    private void Instantiate()
    {
        Material baseMaterial = new Material(gameObject.GetComponent<MeshRenderer>().material);

        baseMaterial.color = _color;
        
        GameObject meshCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        meshCube.transform.position = transform.position;
        Vector3 currentScale = transform.localScale;
        currentScale *= _reduceModifier;
        meshCube.transform.localScale = currentScale;
        meshCube.GetComponent<MeshRenderer>().material = baseMaterial;


        meshCube.AddComponent<Rigidbody>();
        Cube cube = meshCube.AddComponent<Cube>();
        cube._spawnChance = _spawnChance * _reduceModifier;
        cube._explosionFX = _explosionFX;
    }

    private Color CreateRandomColor()
    {
        float red = Random.Range(byte.MinValue, byte.MaxValue);
        float green = Random.Range(byte.MinValue, byte.MaxValue);
        float blue = Random.Range(byte.MinValue, byte.MaxValue);

        return new Color(red,green,blue,.5f);
    }
}
