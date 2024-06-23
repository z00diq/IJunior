using System;
using UnityEngine;

public class EnemyDestoryer: MonoBehaviour
{
    public event Action<Enemy> EnemyTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
             EnemyTriggered?.Invoke(enemy);
        }
    }
}