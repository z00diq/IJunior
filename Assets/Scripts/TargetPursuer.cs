using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class TargetPursuer
    {
        private Transform _self;
        private Transform _target;
        private float _chaseSpeed;
        private bool _contChase;

        public TargetPursuer(Transform self, Transform target, float chaseSpeed)
        {
            _self = self;
            _target = target;
            _chaseSpeed = chaseSpeed;
        }

        internal void StopChase()
        {
            _contChase = false;
        }

        internal IEnumerator StartChase()
        {
            _contChase = true;
            var wait = new WaitForEndOfFrame();
            var enumerator = Chase(wait);

            while (_contChase)
            {
                yield return enumerator.MoveNext();
            }
        }

        private IEnumerator Chase(WaitForEndOfFrame waitForEndOfFrame)
        {
            _self.position = Vector3.MoveTowards(_self.position, _target.position, _chaseSpeed * Time.deltaTime);
            yield return waitForEndOfFrame;
        }
    }
}