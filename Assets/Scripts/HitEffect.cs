using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitVFXPrefab;
    [SerializeField] private float _punchCooldown = 1f;

    private float _ellapsedTime = 0f;
    private ParticleSystem _hitVFX = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _ellapsedTime>=_punchCooldown)
        {
            CreateOrLaunchVFX();
            _ellapsedTime = 0;
        }

        _ellapsedTime += Time.deltaTime;
    }

    private void CreateOrLaunchVFX()
    {
        if (_hitVFX == null)
            _hitVFX = Instantiate(_hitVFXPrefab, transform.position, Quaternion.identity,transform);
        else
            _hitVFX.gameObject.SetActive(true);
    }
}
