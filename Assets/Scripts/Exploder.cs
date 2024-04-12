using UnityEngine;

namespace Assets.Scripts
{
    public class Exploder
    {
        private GameObject _explosionFX;

        public Exploder(GameObject explosionFX)
        {
            _explosionFX = explosionFX;
        }

        public void Explode(Transform transform)
        {
            Object.Instantiate(_explosionFX, transform.position, Quaternion.identity);
            Object.Destroy(transform.gameObject);
        }
    }
}
