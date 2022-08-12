using System.Collections.Generic;
using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Weapon> weapons;

        private int currentWeaponIndex;

        public void ChangeWeapon ()
        {
            if (weapons.Count == 0)
                return;

            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
        }
    }
}