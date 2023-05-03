using UnityEngine;

namespace Beta
{
	public class RotationView : MonoBehaviour, IRotationListener
	{
		public void RegisterListener(GameEntity entity) => entity.AddRotationListener(this);

		public void OnRotation(GameEntity entity, float value)
			=> transform.rotation = Quaternion.Euler(0f, 0f, value);
	}
}