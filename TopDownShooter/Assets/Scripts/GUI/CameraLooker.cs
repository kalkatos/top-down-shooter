using UnityEngine;

namespace Kalkatos.TopDownShooter
{
	public class CameraLooker : MonoBehaviour
	{
		private Camera mainCamera;

		private void Awake ()
		{
			mainCamera = Camera.main;
		}

		private void LateUpdate ()
		{
			transform.LookAt(mainCamera.transform, mainCamera.transform.up);
		}
	}
}