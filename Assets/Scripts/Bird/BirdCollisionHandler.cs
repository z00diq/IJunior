using System;
using UnityEngine;

public class BirdCollisionHandler
{
    public Action<IObstacle> CollisionDetected;
    
    public void ProvideCollison(Collider2D collision)
    {
        if(collision.TryGetComponent(out IObstacle obstacle))
            CollisionDetected?.Invoke(obstacle);
    }
}