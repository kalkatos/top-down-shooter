using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    public class EnemyRandomMovement : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private Vector2 randomMoveTime;
        [Header("References")]
        [SerializeField] private Movable movable;
        [SerializeField] private Damageable damageable;

        private float nextChangeInDirectionTime;

        private void Awake ()
        {
            damageable.OnDeath += HandleDeath;
            movable.SetSpeed(moveSpeed);
            SetRandomDirection();
        }

        private void Update ()
        {
            if (Time.time > nextChangeInDirectionTime)
                SetRandomDirection();
        }

        private void SetRandomDirection ()
        {
            movable.SetMovement(Random.insideUnitCircle);
            nextChangeInDirectionTime = Time.time + Random.Range(randomMoveTime.x, randomMoveTime.y);
        }

        private void HandleDeath ()
        {
            movable.SetCanMove(false);
            gameObject.SetActive(false);
        }
    }
}
