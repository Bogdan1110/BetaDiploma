using Mirror;
using UnityEngine;

namespace Beta
{
	public class Networking : NetworkManager
	{
		public override void OnStartServer()
		{
			base.OnStartServer();
			NetworkServer.RegisterHandler<SpawnPlayerMessage>(OnSpawnPlayer);
			NetworkServer.RegisterHandler<PlayerDeathMessage>(OnPlayerDeath);
		}

		private void OnSpawnPlayer(NetworkConnectionToClient connection, SpawnPlayerMessage message)
		{
			var player = Instantiate(playerPrefab, message.Position, Quaternion.identity);
			NetworkServer.AddPlayerForConnection(connection, player);
		}

		private void OnPlayerDeath(NetworkConnectionToClient connection, PlayerDeathMessage message) { }
	}
}