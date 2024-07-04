using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _duration = 3; 
    [SerializeField] private Vector3 _fullAngleY = new Vector3(0, 360, 0);
    
    private void Start()
    {
        transform.DORotate(_fullAngleY, _duration, RotateMode.FastBeyond360).
            SetLoops(-1,LoopType.Yoyo).
            SetEase(Ease.Linear);
    }
}
