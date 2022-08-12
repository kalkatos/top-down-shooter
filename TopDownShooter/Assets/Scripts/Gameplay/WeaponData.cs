using System.Collections;
using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Top Down Shooter/Weapon")]
    public class WeaponData : ScriptableObject
    {
        public Projectile ProjectilePrefab;
        public float FireRate;
        public bool IsAutomatic;
        public int ProjectilePoolSize;
        public float ProjectileSpeed;
        public int ProjectileDamage;
        public float ProjectileDuration;
    }
}