using System.Collections;
using System.Collections.Generic;
using Control;
using UnityEngine;

namespace BulletHell
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private MovementBehaviour movementBehaviour;

        private void Awake()
        {
            movementBehaviour.SetTarget(transform);
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(AxisHolder.Horizontal);
            float vertical = Input.GetAxis(AxisHolder.Vertical);

            Vector2 input = new Vector2(horizontal, vertical);

            if (input != Vector2.zero)
                movementBehaviour.Move(input);
        }
    }
}