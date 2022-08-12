using System;
using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    public delegate void HealthEvent (int currentHealth, int maxHealth);

    public class Damageable : MonoBehaviour
    {
        public event Action OnDeath;
        public event HealthEvent OnHealthChanged;

        [SerializeField] private int maxHealth;

        private int currentHealth;

        private void Start ()
        {
            currentHealth = maxHealth;
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        private void OnTriggerEnter (Collider other)
        {
            if (other.TryGetComponent(out DamageDealer damageDealer))
            {
                currentHealth = Mathf.Max(currentHealth - damageDealer.Damage, 0);
                OnHealthChanged?.Invoke(currentHealth, maxHealth);
                if (currentHealth == 0)
                    OnDeath?.Invoke();
            }
        }

        public void SetHealth (int value)
        {
            currentHealth = value;
            maxHealth = value;
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }
}
