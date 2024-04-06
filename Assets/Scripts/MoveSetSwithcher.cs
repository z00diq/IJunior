using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class MoveSetSwithcher
    {
        private PatrolMover _patrol;
        private TargetPursuer _pursuer;
        private float _distanceToActivate;
        private Transform _self;
        private Transform _target;

        public MoveSetSwithcher(PatrolMover patrol, TargetPursuer pursuer, float distanceToActivate, Transform self, Transform target)
        {
            _patrol = patrol;
            _pursuer = pursuer;
            _distanceToActivate = distanceToActivate;
            _self = self;
            _target = target;
        }

        public void Update()
        {
            Vector2 substract = _target.position - _self.position;
            var enumerator = _pursuer.StartChase();

            if (substract.magnitude < _distanceToActivate)
            {
                _patrol.enabled = false;
                enumerator.MoveNext();
            }
            else
            {
                _pursuer.StopChase();
                _patrol.enabled = true;
            }
        }
    }
}
