using Mirror;
using UnityEngine;

namespace Beta
{
	public struct SpawnPlayerMessage : NetworkMessage
	{
		public Vector2 Position;
	}

	public struct PlayerDeathMessage : NetworkMessage { }
}