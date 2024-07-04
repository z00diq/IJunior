using DG.Tweening;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration=5f;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.DOColor(_targetColor,_duration).
            SetLoops(-1).SetEase(Ease.Flash);
    }
}
