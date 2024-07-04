using DG.Tweening;
using UnityEngine;

public class CubeTransformer : MonoBehaviour
{
    private float _duration = 5;
    private Vector3 _moveVector = new Vector3(1, 10, 7);
    private Vector3 _rotateVector = new Vector3(180, 360, 90);
    private Vector3 _scaleVector = new Vector3(3f,7f,2f);

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(_moveVector, _duration).SetRelative(false));
        sequence.Insert(0f, transform.DORotate(_rotateVector, _duration));
        sequence.Insert(0f,transform.DOScale(_scaleVector, _duration));

        sequence.SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InSine);
    }
}
