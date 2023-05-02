namespace Beta
{
	public static class PlayerEntityExtensions
	{
		public static bool IsOwned(this GameEntity @this) => @this.networkIdentity.Value.isOwned;
	}
}