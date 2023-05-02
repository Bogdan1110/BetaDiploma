using UnityEngine;

namespace Beta
{
	public interface ICameraService
	{
		Vector2 ScreenToWorldPoint(Vector2 screenPosition);
	}

	public class CameraService : ICameraService
	{
		private static Camera Camera => Camera.main;

		public Vector2 ScreenToWorldPoint(Vector2 screenPosition)
			=> Camera.ScreenToWorldPoint(screenPosition);
	}
}