using System;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    public event Action ThiefCameIn;
    public event Action ThiefCameOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
            ThiefCameIn?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
            ThiefCameOut?.Invoke();
    }
}
