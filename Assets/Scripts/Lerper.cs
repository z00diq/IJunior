using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    [SerializeField] private Vector3 _startPoition = new Vector3(-4, 0, 0);
    [SerializeField] private Vector3 _endtPoition = new Vector3(4, 0, 0);

    private IEnumerator enumerator;


    private void Start()
    {
        enumerator = aaa();
    }

    private void Update()
    {
        aaa() .MoveNext();

    }

    private IEnumerator aaa()
    {
        while (transform.position != _endtPoition)
        {
            Vector3 distance = transform.position - _endtPoition;
            float deltaDitnce = distance.magnitude * Time.fixedDeltaTime;
            Vector3 deltaVector = Vector3.right * deltaDitnce;
            transform.Translate(deltaVector);
            Debug.Log("rfr");
            yield return new();
        }

        Debug.Log("KONCHA");
    }
}
