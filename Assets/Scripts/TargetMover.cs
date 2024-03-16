using UnityEngine;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class TargetMover:MonoBehaviour
    {
        [SerializeField] private Transform[] _pathPoints;

        private Transform _nextPathPoint;
        private int _currentPathPointIndex = 0;
        private bool isMove = true;

        private void OnEnable()
        {
            isMove = true;
        }

        private void OnDisable()
        {
            isMove = false;
        }

        private void Update()
        {
                
        }

        private async void AA()
        {
            while (isMove)
            {

                await Task.Run((Transform transform) =>
                );
            }
        }
    }
}