using UnityEngine;

namespace Beta
{
	public class PositionView : MonoBehaviour, IPositionListener
	{
		public void RegisterListener(GameEntity entity) => entity.AddPositionListener(this);

		public void OnPosition(GameEntity entity, Vector2 value) => transform.position = value;
	}
}