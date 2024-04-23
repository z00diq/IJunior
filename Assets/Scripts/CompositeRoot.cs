using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompositeRoot : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private HealthIndicator[] _indicators;
    [SerializeField] private float _maxHealthValue;

    [Header("Simulation Buttons")]
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;

    [Header("Applaying Values")]
    [SerializeField] private float _damageValue;
    [SerializeField] private float _healValue;

    private Health _health;

    private void Awake()
    {
        _health = new Health(_maxHealthValue);
    }

    private void Start()
    {
        _health.Initialize();
    }

    private void OnEnable()
    {
        foreach (HealthIndicator indicator in _indicators)
        {
            indicator.Initialize(_health);
        }

        _damageButton.onClick.AddListener(() => _health.TakeDamage(_damageValue));
        _healButton.onClick.AddListener(() => _health.RestoreHealth(_healValue));
    }

    private void OnDisable()
    {
        foreach (HealthIndicator indicator in _indicators)
        {
            indicator.Decompile();
        }

        _damageButton.onClick.RemoveAllListeners();
        _healButton.onClick.RemoveAllListeners();
    }
}
