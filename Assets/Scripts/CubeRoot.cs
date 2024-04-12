using Assets.Scripts;
using UnityEngine;

public class CubeRoot : MonoBehaviour
{
    [SerializeField] private GameObject _explosionFX;
    [SerializeField] private CubeSpawnConfiguration _configuration;
    
    private Exploder _exploder;
    public CubeSpawnConfiguration Configuration => _configuration;

    private void Awake()
    {
        _exploder = new Exploder(_explosionFX);
    }

    public void Explode()
    {
        _exploder.Explode(transform);
    }
    
    public void Instantiate()
    {
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.transform.position = transform.position;
        newCube.transform.localScale = _configuration.Scale;

        newCube.GetComponent<MeshRenderer>().material.color = CreateRandomColor();
        newCube.AddComponent<Rigidbody>();

        var root = newCube.AddComponent<CubeRoot>();
        root._configuration = Configuration.RecalculateConfiguration();
        root._exploder = _exploder;
    }

    private Color CreateRandomColor()
    {
        float red = Random.Range(0f,1f);
        float green = Random.Range(0f, 1f); ;
        float blue = Random.Range(0f, 1f); ;

        return new Color(red,green,blue);
    }
}
