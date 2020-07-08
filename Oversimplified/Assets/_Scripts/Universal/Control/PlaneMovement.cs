using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    public class PlaneMovement : MovementBehaviour
    {
        [SerializeField] private PlaneOrientation planeOrientation;
   
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float verticalSpeed;
        [SerializeField] private float diagonalMaxSpeed;
    
        public override void Move(Vector2 input)
        {
            Vector2 movement = input;

            movement.x *= horizontalSpeed * Time.deltaTime;
            movement.y *= verticalSpeed * Time.deltaTime;

            movement = Vector3.ClampMagnitude(movement, diagonalMaxSpeed * Time.deltaTime);

            _target.Translate(GetPlaneMovementVector(movement, planeOrientation));
        }

        private Vector3 GetPlaneMovementVector(Vector2 movement, PlaneOrientation planeOrientation)
        {
            Vector3 result = Vector3.zero;

            switch (planeOrientation)
            {
                case PlaneOrientation.XnY:
                    result = movement;
                    break;

                case PlaneOrientation.XnZ:
                    result.x = movement.x;
                    result.z = movement.y;
                    break;

                case PlaneOrientation.YnZ:
                    result.y = movement.x;
                    result.z = movement.y;
                    break;
            }

            return result;
        }
    }

    internal enum PlaneOrientation
    {
        XnY,
        XnZ,
        YnZ
    }
}


