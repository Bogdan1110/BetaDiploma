using Mirror;
using UnityEngine;

namespace Beta
{
	public static class MessageExtensions
	{
		public static void SendAsSpawnPlayerMessage(this Vector2 @this)
			=> NetworkClient.Send(new SpawnPlayerMessage { Position = @this });
	}
}