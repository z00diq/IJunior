using UnityEngine;

public class CapsuleScaler : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private Vector3 _maxScale;
    private Vector3 _startScale;
    private Vector3 deltaScale;

    private void Start()
    {
        _startScale = transform.localScale;
        deltaScale = Vector3.one *  _scaleSpeed * Time.deltaTime;
    }

    private void Update()
    {
        transform.localScale += deltaScale;

        if (transform.localScale.magnitude >= _maxScale.magnitude || 
            transform.localScale.magnitude <= Vector3.one.magnitude)
            deltaScale = -deltaScale;
    }
}
