using UnityEngine;
using UnityEngine.EventSystems;

namespace Kalkatos.TopDownShooter
{
    public delegate void JoystickEvent (Vector2 position);

    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public static Joystick Instance;

        public static event JoystickEvent OnJoystickDown;
        public static event JoystickEvent OnJoystickDrag;
        public static event JoystickEvent OnJoystickUp;

        [SerializeField] private float screenSizeInInches;

        private Vector2 currentInput;
        private bool isTouching;
        private Vector2 inputStartPos;
        private float size;

        public static float ScreenSize => Instance.size;
        public static Vector2 CurrentInput => Instance.currentInput;
        public static bool IsTouching => Instance.isTouching;

        private void Awake ()
        {
            Instance = this;
            size = Screen.dpi * (screenSizeInInches / 2);
        }

        public void OnPointerDown (PointerEventData eventData)
        {
            OnJoystickDown?.Invoke(eventData.position);
            inputStartPos = eventData.position;
            isTouching = true;
        }

        public void OnDrag (PointerEventData eventData)
        {
            OnJoystickDrag?.Invoke(eventData.position);
            currentInput = Vector3.ClampMagnitude(eventData.position - inputStartPos, size) / size;
        }

        public void OnPointerUp (PointerEventData eventData)
        {
            OnJoystickUp?.Invoke(eventData.position);
            currentInput = Vector2.zero;
            isTouching = false;
        }
    }
}