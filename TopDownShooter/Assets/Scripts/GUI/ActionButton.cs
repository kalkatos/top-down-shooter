using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kalkatos.TopDownShooter
{
    public abstract class ActionButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake ()
        {
            button.onClick.AddListener(SendActionEvent);
        }

        private void OnDestroy ()
        {
            button.onClick.RemoveListener(SendActionEvent);
        }

        protected virtual void SendActionEvent () {  }
    }
}
