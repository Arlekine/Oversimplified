using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    public abstract class MovementBehaviour : MonoBehaviour
    {
        protected Transform _target;

        public virtual void SetTarget(Transform target)
        {
            _target = target;
        }

        public abstract void Move(Vector2 input);
    }
}
