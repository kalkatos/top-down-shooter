using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kalkatos.TopDownShooter
{
    [RequireComponent(typeof(Shooter), typeof(Movable), typeof(Damageable))]
    public class Player : MonoBehaviour
    {
        public static event Action OnPlayerDead;

        [Header("Config")]
        [SerializeField] private float moveSpeed;
        [Header("References")]
        [SerializeField] private List<Weapon> weapons;
        [SerializeField] private Shooter shooter;
        [SerializeField] private Movable movable;
        [SerializeField] private Damageable damageable;

        private int currentWeaponIndex;

        private void Awake ()
        {
            ShootButton.OnDown += HandleShootBegin;
            ShootButton.OnUp += HandleShootEnd;
            ChangeWeaponButton.OnPressed += HandleChangeWeaponAction;
            damageable.OnDeath += HandlePlayerDeath;
            movable.SetSpeed(moveSpeed);
        }

        private void OnDestroy ()
        {
            ShootButton.OnDown -= HandleShootBegin;
            ShootButton.OnUp -= HandleShootEnd;
            ChangeWeaponButton.OnPressed -= HandleChangeWeaponAction;
            damageable.OnDeath -= HandlePlayerDeath;
        }

        private void Update ()
        {
            if (Joystick.IsTouching)
                movable.SetMovement(Joystick.CurrentInput);
            else
                movable.SetMovement(Vector2.zero);
        }

        private void HandleShootBegin ()
        {
            shooter.Begin();
        }

        private void HandleShootEnd ()
        {
            shooter.End();
        }

        private void HandleChangeWeaponAction ()
        {
            if (weapons.Count == 0)
                return;

            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            Weapon newWeapon = weapons[currentWeaponIndex];
            shooter.SetWeapon(newWeapon);
            for (int i = 0; i < weapons.Count; i++)
                weapons[i].gameObject.SetActive(newWeapon == weapons[i]);
        }

        private void HandlePlayerDeath ()
        {
            OnPlayerDead?.Invoke();
            movable.SetCanMove(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
