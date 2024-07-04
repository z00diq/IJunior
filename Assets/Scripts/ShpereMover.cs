using DG.Tweening;
using UnityEngine;

public class ShpereMover : MonoBehaviour
{
    [SerializeField] private Vector3 _endPoint;
    [SerializeField] private float _duration = 3f;

    private void Start()
    {
        transform.DOMove(_endPoint, _duration).
            SetLoops(-1, LoopType.Yoyo).
            SetEase(Ease.Linear);
    }
}
