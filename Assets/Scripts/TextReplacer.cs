using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextReplacer : MonoBehaviour
{
    private const string ReplaceString = "mudamudamudamuda";
    private const string AppendString = "oraoraoraoraora";
    private const string BruteForceString = "yamete kudasai senpai";
    
    [SerializeField] private float _duration = 3f;

    private void Start()
    {
        Text myText = gameObject.GetComponent<Text>();

        Sequence sequence = DOTween.Sequence();
        sequence.Append(myText.DOText(ReplaceString, _duration));
        sequence.Append(myText.DOText(AppendString, _duration).SetRelative());
        sequence.Append(myText.DOText(BruteForceString, _duration, true, ScrambleMode.All));

        sequence.SetLoops(-1, LoopType.Yoyo);
    }
}
