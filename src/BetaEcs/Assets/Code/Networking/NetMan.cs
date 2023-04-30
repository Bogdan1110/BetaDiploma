using Mirror;

namespace Beta
{
	public class NetMan : NetworkManager
	{
		public override void OnServerAddPlayer(NetworkConnectionToClient conn)
		{
			// Spawn the Mirror player object
			var playerObject = Instantiate(playerPrefab);
			NetworkServer.AddPlayerForConnection(conn, playerObject);

			// Create an Entitas player entity
			var playerEntity = Contexts.sharedInstance.game.CreateEntity();
			playerEntity.isPlayer = true;
			playerEntity.AddPosition(playerObject.transform.position);
			playerEntity.AddNetworkIdentity(playerObject.GetComponent<NetworkIdentity>());
		}
	}
}