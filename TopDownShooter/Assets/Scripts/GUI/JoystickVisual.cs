using System;
using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    public class JoystickVisual : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private GameObject background;
        [SerializeField] private RectTransform stick;

        [SerializeField] private float visualSize;

        private Camera canvasCamera;
        private RectTransform myRectTransform;
        private RectTransform backgroundRectTransform;

        private void Awake ()
        {
            Joystick.OnJoystickDown += HandleJoystickDown;
            Joystick.OnJoystickUp += HandleJoystickUp;

            if (canvas == null)
                canvas = GetComponentInParent<Canvas>();
            canvasCamera = canvas.worldCamera;
            background.SetActive(false);
            myRectTransform = (RectTransform)transform;
            backgroundRectTransform = (RectTransform)background.transform;
            visualSize = Screen.dpi;
        }

        private void OnDestroy ()
        {
            Joystick.OnJoystickDown -= HandleJoystickDown;
            Joystick.OnJoystickUp -= HandleJoystickUp;
        }

        private void Update ()
        {
            stick.anchoredPosition = Joystick.CurrentInput * visualSize;
        }

        private void HandleJoystickDown (Vector2 position)
        {
            backgroundRectTransform.anchoredPosition = ScreenToAnchoredPosition(myRectTransform, position);
            background.SetActive(true);
        }

        private void HandleJoystickUp (Vector2 position)
        {
            background.SetActive(false);
        }

        private Vector2 ScreenToAnchoredPosition (RectTransform rect, Vector2 screenPos)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPos, canvasCamera, out Vector2 localPoint);
            return localPoint;
        }
    }
}