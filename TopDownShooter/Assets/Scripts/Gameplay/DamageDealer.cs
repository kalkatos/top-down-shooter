using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private int damage;

        public int Damage => damage;

        public void SetDamage (int value)
        {
            damage = value;
        }
    }
}
