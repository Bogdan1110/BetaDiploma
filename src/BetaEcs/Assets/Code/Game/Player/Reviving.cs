using System.Collections;
using Mirror;
using UnityEngine;

namespace Beta
{
	public class Reviving : NetworkBehaviour
	{
		private const float Cooldown = 1f;
		private static PlayerBehaviour PlayerPrefab => Resources.Load<PlayerBehaviour>("Player/Player");

		public void Revive()
		{
			StartCoroutine(SpawnAfterCooldown());
		}

		private IEnumerator SpawnAfterCooldown()
		{
			yield return new WaitForSeconds(Cooldown);

			Spawn();
		}

		private void Spawn() => this.Perform(onServer: RpcSpawnPlayerObject, onClient: CmdSpawnPlayerObject);

		[ClientRpc] private void RpcSpawnPlayerObject() => SpawnPlayerObject();

		[Command] private void CmdSpawnPlayerObject() => SpawnPlayerObject();

		private void SpawnPlayerObject()
		{
			if (isServer)
			{
				var newPlayerObject = Instantiate(PlayerPrefab).gameObject;
				Debug.Log($"connectionToClient is not null = {connectionToClient is not null}");
				NetworkServer.ReplacePlayerForConnection(connectionToClient, newPlayerObject);
			}
		}
	}
}