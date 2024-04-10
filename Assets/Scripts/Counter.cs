using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _text;

    private float _value = 0;
    private float _updateTime = 0.5f;
    private Coroutine _update = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_update != null)
            {
                StopCoroutine(_update);
                _update = null;
                return;
            }

            _update = StartCoroutine(nameof(UpdateCounter));
        }
    }


    private IEnumerator UpdateCounter()
    {
        var waiter = new WaitForSecondsRealtime(_updateTime);

        while (true)
        {
            _text.text = (_value++).ToString();
            yield return waiter;
        }
    }
}
