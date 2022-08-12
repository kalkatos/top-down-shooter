using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kalkatos.TopDownShooter
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Damageable damageable;
        [SerializeField] private Image fillImage;

        private void Awake ()
        {
            damageable.OnHealthChanged += HandleHealthChanged;
        }

        private void OnDestroy ()
        {
            damageable.OnHealthChanged -= HandleHealthChanged;
        }

        private void HandleHealthChanged (int currentHealth, int maxHealth)
        {
            fillImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
