using UnityEngine;

public class Coin:MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Mover mover))
            Destroy(gameObject);
    }
}