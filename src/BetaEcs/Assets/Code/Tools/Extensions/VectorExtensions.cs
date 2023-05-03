using UnityEngine;

namespace Beta
{
	public static class VectorExtensions
	{
		public static float DistanceTo(this Vector2 @this, Vector2 other)
			=> Vector2.Distance(@this, other);
	}
}