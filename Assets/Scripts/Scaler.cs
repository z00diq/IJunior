using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Vector3 _endScale = new Vector3 (4f,4f,4f);
    [SerializeField] private float _duration = 6f;

    private void Start()
    {
        transform.DOScale(_endScale, _duration).SetLoops(-1,LoopType.Yoyo);
    }
}
