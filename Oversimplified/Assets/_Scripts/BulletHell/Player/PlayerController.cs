using System.Collections;
using System.Collections.Generic;
using Control;
using UnityEngine;

namespace BulletHell
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private MovementBehaviour movementBehaviour;
        [SerializeField] private Health health;

        private void Awake()
        {
            movementBehaviour.SetTarget(transform);

            health.onTakeDamage += PlayerDamaged;
            health.onHealthEnd += PlayerDeath;
        }

        private void PlayerDamaged(int currentHealth)
        {
            Debug.Log("Damaged: " + currentHealth);
        }

        private void PlayerDeath()
        {
            Debug.Log("Player dead");
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