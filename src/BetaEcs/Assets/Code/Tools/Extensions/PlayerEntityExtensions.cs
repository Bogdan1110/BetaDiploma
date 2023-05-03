using UnityEngine.Assertions;

namespace Beta
{
	public static class PlayerEntityExtensions
	{
		public static bool IsOwned(this GameEntity @this)
		{
			Assert.IsTrue(@this.hasNetworkIdentity);

			return @this.networkIdentity.Value.isOwned;
		}
	}
}