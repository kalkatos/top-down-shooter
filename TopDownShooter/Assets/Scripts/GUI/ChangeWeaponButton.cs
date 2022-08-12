using System;

namespace Kalkatos.TopDownShooter
{
    public class ChangeWeaponButton : ActionButton
    {
        public static event Action OnPressed;

        protected override void SendActionEvent ()
        {
            OnPressed?.Invoke();
        }
    }
}
