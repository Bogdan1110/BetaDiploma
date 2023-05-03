namespace Beta
{
	public static class CollisionExtensions
	{
		public static void MutualCollideWith(this GameEntity @this, GameEntity other)
		{
			@this.isCollided = true;
			@this.AddCollisionId(other.id.Value);

			other.isCollided = true;
			other.AddCollisionId(@this.id.Value);
		}
	}
}