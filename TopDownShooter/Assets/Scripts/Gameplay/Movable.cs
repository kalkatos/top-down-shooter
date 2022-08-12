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
            if (canMove && movement != Vector3.zero)
            {
                myTransform.forward = movement;
                rb.velocity = myTransform.forward * speed;
            }
            else
                rb.velocity = Vector3.zero;
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
