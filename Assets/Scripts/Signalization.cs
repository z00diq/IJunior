using System;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    public event Action ThiefCameIn;
    public event Action ThiefCameOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Thief>() != null)
            ThiefCameIn?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Thief>() != null)
            ThiefCameOut?.Invoke();
    }
}
