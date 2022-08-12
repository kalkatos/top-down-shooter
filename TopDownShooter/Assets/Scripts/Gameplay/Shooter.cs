using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;

        public void SetWeapon (Weapon newWeapon)
        {
            weapon = newWeapon;
        }

        public void Begin ()
        {
            weapon.PullTrigger();
        }

        public void End ()
        {
            weapon.ReleaseTrigger();
        }
    }
}
