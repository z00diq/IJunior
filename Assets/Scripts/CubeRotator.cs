using DG.Tweening;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [SerializeField] private float _duration = 3;
    
    private Vector3 _fullAngleY = new Vector3(0, 360, 0);
    
    private void Start()
    {
        transform.DORotate(_fullAngleY, _duration, RotateMode.FastBeyond360).
            SetLoops(-1).
            SetEase(Ease.Linear);
    }
}
