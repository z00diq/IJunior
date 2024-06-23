using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private float _xOffset;
    
    private Bird _bird;

    public void Initialize(Bird bird)
    {
        _bird = bird;
    }

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _bird.transform.position.x + _xOffset;
        transform.position = position;
    }
}
