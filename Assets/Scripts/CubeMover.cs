using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime);

    }
}

