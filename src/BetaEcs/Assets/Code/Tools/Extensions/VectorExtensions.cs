using UnityEngine;

namespace Beta
{
	public static class VectorExtensions
	{
		public static float DistanceTo(this Vector2 @this, Vector2 other)
			=> Vector2.Distance(@this, other);

		public static Vector2 Clamp(this Vector2 @this, Vector2 min, Vector2 max)
		{
			var x = Mathf.Clamp(@this.x, -min.x, max.x);
			var y = Mathf.Clamp(@this.y, -min.y, max.y);

			return new Vector2(x, y);
		}
	}
}