using System.Collections.Generic;
using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData data;
        [SerializeField] private LayerMask projectileLayer;
        [SerializeField] private Transform projectileSpawnPos;

        private List<Projectile> projectilePool = new List<Projectile>();
        private List<Projectile> activeProjectiles = new List<Projectile>();

        private bool isShooting;
        private float lastShootTime;

        private void Awake ()
        {
            for (int i = 0; i < data.ProjectilePoolSize; i++)
                CreateProjectile();
        }

        private void Update ()
        {
            if (!isShooting)
                return;

            if (Time.time - lastShootTime >= data.FireRate)
            {
                lastShootTime = Time.time;
                Shoot();
            }
        }

        private void Shoot ()
        {
            if (projectilePool.Count > 0)
            {
                Projectile projectile = projectilePool[0];
                activeProjectiles.Add(projectile); 
                projectilePool.Remove(projectile);
                projectile.transform.SetPositionAndRotation(projectileSpawnPos.position, projectileSpawnPos.rotation);
                projectile.transform.SetParent(null);
                projectile.gameObject.SetActive(true);
            }
            else
            {
                CreateProjectile();
                Debug.LogWarning($"Weapon {data.name} is creating projectile instances on the fly. Please increase pool size.");
            }
        }

        private void CreateProjectile ()
        {
            Projectile newProj = Instantiate(data.ProjectilePrefab);
            newProj.transform.SetParent(transform);
            newProj.SetSpeed(data.ProjectileSpeed);
            newProj.SetDuration(data.ProjectileDuration);
            newProj.SetDamage(data.ProjectileDamage);
            newProj.OnDisabled += HandleProjectileDisabled;
            projectilePool.Add(newProj);
            newProj.gameObject.layer = 1 << projectileLayer.value;
            newProj.gameObject.SetActive(false);
        }

        private void HandleProjectileDisabled (Projectile projectile)
        {
            activeProjectiles.Remove(projectile);
            projectilePool.Add(projectile);
            projectile.transform.SetParent(transform);
        }

        public void PullTrigger ()
        {
            Shoot();
            lastShootTime = Time.time;
            if (data.IsAutomatic)
                isShooting = true;
        }

        public void ReleaseTrigger ()
        {
            isShooting = false;
        }
    }
}