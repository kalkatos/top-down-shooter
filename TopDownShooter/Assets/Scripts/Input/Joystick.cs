using UnityEngine;
using UnityEngine.EventSystems;

namespace Kalkatos.TopDownShooter
{
    public delegate void JoystickEvent (Vector2 position);

    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public static Joystick Instance;

        public static event JoystickEvent OnJoystickDown;
        public static event JoystickEvent OnJoystickUp;

        [SerializeField] private float screenSize;

        public Vector2 ScreenInput;
        public Vector2 currentInput;
        private bool isTouching;
        private Vector2 inputStartPos;

        public static float ScreenSize => Instance.screenSize;
        public static Vector2 CurrentInput => Instance.currentInput;
        public static bool IsTouching => Instance.isTouching;

        private void Awake ()
        {
            Instance = this;
            screenSize = Screen.dpi;
        }

        public void OnPointerDown (PointerEventData eventData)
        {
            inputStartPos = eventData.position;
            OnJoystickDown?.Invoke(eventData.position);
            isTouching = true;
        }

        public void OnDrag (PointerEventData eventData)
        {
            ScreenInput = eventData.position - inputStartPos;
            currentInput = Vector3.ClampMagnitude(eventData.position - inputStartPos, screenSize) / screenSize;
        }

        public void OnPointerUp (PointerEventData eventData)
        {
            OnJoystickUp?.Invoke(eventData.position);
            ScreenInput = Vector2.zero;
            currentInput = Vector2.zero;
            isTouching = false;
        }
    }
}