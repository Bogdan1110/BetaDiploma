using UnityEngine;

namespace Beta
{
	public interface IPhysicsService
	{
		int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] buffer);
	}

	public class PhysicsService
		: IPhysicsService
	{
		public int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] buffer)
			=> Physics2D.OverlapCircleNonAlloc(point, radius, buffer);
	}
}