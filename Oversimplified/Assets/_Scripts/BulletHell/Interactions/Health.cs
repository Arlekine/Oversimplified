using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell
{
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// Sends amount of health after damage
        /// </summary>
        public Action<int> onTakeDamage;
        public Action onHealthEnd;

        [SerializeField] private int maxHealth;

        private int _currentHealth;

        void Awake()
        {
            _currentHealth = maxHealth;
        }

        private void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            onTakeDamage?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                onHealthEnd?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IDamageDealer>() != null)
            {
                TakeDamage(1);
            }
        }
    }
}