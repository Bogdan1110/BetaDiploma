using System.Collections;
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
		}

		private void OnSpawnPlayer(NetworkConnectionToClient connection, SpawnPlayerMessage message)
			=> StartCoroutine(Spawn(connection, message));

		private IEnumerator Spawn(NetworkConnectionToClient connection, SpawnPlayerMessage message)
		{
			yield return new WaitForSeconds(1f);

			var player = Instantiate(playerPrefab, message.Position, Quaternion.identity);
			NetworkServer.AddPlayerForConnection(connection, player);
		}
	}
}