using System;
using UnityEngine;

namespace Kalkatos.TopDownShooter
{
    public class JoystickVisual : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private GameObject background;
        [SerializeField] private RectTransform stick;

        private Camera canvasCamera;
        private RectTransform myRectTransform;
        private RectTransform backgroundRectTransform;
        private Vector2 startingPosition;

        private void Awake ()
        {
            Joystick.OnJoystickDown += HandleJoystickDown;
            Joystick.OnJoystickDrag += HandleJoystickDrag;
            Joystick.OnJoystickUp += HandleJoystickUp;

            if (canvas == null)
                canvas = GetComponentInParent<Canvas>();
            canvasCamera = canvas.worldCamera;
            background.SetActive(false);
            myRectTransform = (RectTransform)transform;
            backgroundRectTransform = (RectTransform)background.transform;
        }

        private void OnDestroy ()
        {
            Joystick.OnJoystickDown -= HandleJoystickDown;
            Joystick.OnJoystickDrag -= HandleJoystickDrag;
            Joystick.OnJoystickUp -= HandleJoystickUp;
        }

        private void HandleJoystickDown (Vector2 position)
        {
            backgroundRectTransform.anchoredPosition = ScreenToAnchoredPosition(myRectTransform, position);
            background.SetActive(true);
            startingPosition = position;
        }

        private void HandleJoystickDrag (Vector2 position)
        {
            position = startingPosition + Vector2.ClampMagnitude(position - startingPosition, Joystick.ScreenSize);
            stick.anchoredPosition = ScreenToAnchoredPosition(backgroundRectTransform, position);
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