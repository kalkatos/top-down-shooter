using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movable : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;

        private bool canMove = true;
        private float speed;
        private Vector3 movement;
        private Transform myTransform;

        private void Awake ()
        {
            myTransform = transform;
        }

        private void FixedUpdate ()
        {
            Vector3 newVelocity = rb.velocity;
            if (canMove && movement != Vector3.zero)
            {
                myTransform.forward = movement;
                newVelocity.x = movement.x * speed;
                newVelocity.z = movement.z * speed;
                rb.velocity = newVelocity;
            }
            else
            {
                newVelocity.x = 0;
                newVelocity.z = 0;
                rb.velocity = newVelocity; 
            }
        }

        public void SetSpeed (float value)
        {
            speed = value;
        }

        public void SetMovement (Vector2 direction)
        {
            movement = new Vector3(direction.x, 0, direction.y);
        }

        public void SetMovement (Vector3 direction)
        {
            movement = direction;
        }

        public void SetCanMove (bool value)
        {
            canMove = value;
        }
    }
}
