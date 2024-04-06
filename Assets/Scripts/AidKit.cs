using UnityEngine;

namespace Assets.Scripts
{
    internal class AidKit: MonoBehaviour
    {
        [SerializeField] private float _value;

        public float Value => _value;
    }
}