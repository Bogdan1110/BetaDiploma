using Mirror;
using UnityEngine;

namespace Beta
{
	public class Networking : NetworkManager
	{
		public override void OnStartServer()
		{
			base.OnStartServer();
			NetworkServer.RegisterHandler<SpawnPlayerMessage>(OnCreateCharacter);
		}

		private void OnCreateCharacter(NetworkConnectionToClient connection, SpawnPlayerMessage message)
		{
			var player = Instantiate(playerPrefab, message.Position, Quaternion.identity);
			NetworkServer.AddPlayerForConnection(connection, player);
		}
	}
}