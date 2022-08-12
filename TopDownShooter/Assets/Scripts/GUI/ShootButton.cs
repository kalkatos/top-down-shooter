using System;
using UnityEngine.EventSystems;

namespace Kalkatos.TopDownShooter
{
    public class ShootButton : ActionButton, IPointerDownHandler, IPointerUpHandler
    {
        public static event Action OnDown;
        public static event Action OnUp;

        public void OnPointerDown (PointerEventData eventData)
        {
            OnDown?.Invoke();
        }

        public void OnPointerUp (PointerEventData eventData)
        {
            OnUp?.Invoke();
        }
    }
}
