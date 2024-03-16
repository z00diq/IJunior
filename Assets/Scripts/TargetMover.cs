using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

namespace Assets.Scripts
{
    public class TargetMover:MonoBehaviour
    {
        [SerializeField] private Transform[] _pathPoints;

        private int _index = 0;
        private bool isMove = true;
        private IEnumerator _enumerator;

        private void OnEnable()
        {
            isMove = true;
        }

        private void OnDisable()
        {
            isMove = false;
        }

        private void Start()
        {
            _enumerator = Move();
        }

        private void Update()
        {
            _enumerator.MoveNext();
        }

        private IEnumerator  Move()
        {

            while (isMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, _pathPoints[_index].position, Time.deltaTime);
                new WaitWhile(() => transform.position != _pathPoints[_index].position);

                _index++;

                if (_index == _pathPoints.Length)
                    _index = 0;
            }

            yield break;
        }
    }
}