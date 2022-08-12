using System;
using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    [RequireComponent(typeof(Movable), typeof(DamageDealer))]
    public class Projectile : MonoBehaviour
    {
        public event Action<Projectile> OnHit;
        public event Action<Projectile> OnDisabled;

        [SerializeField] private Movable movable;
        [SerializeField] private DamageDealer damageDealer;

        private float duration;
        private float startTime;

        private void OnEnable ()
        {
            startTime = Time.time;
            movable.SetMovement(transform.forward);
        }

        private void OnTriggerEnter (Collider other)
        {
            gameObject.SetActive(false);
            OnHit?.Invoke(this);
            OnDisabled?.Invoke(this);
        }

        private void Update ()
        {
            if (Time.time - startTime >= duration)
            {
                gameObject.SetActive(false);
                OnDisabled?.Invoke(this);
            }
        }

        public void SetSpeed (float value)
        {
            movable.SetSpeed(value);
        }

        public void SetDuration (float value)
        {
            duration = value;
        }

        public void SetDamage (int value)
        {
            damageDealer.SetDamage(value);
        }
    }
}