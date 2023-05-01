using Entitas;
using Mirror;
using UnityEngine;

namespace Beta
{
	public class PlayerSpawnSystem : IInitializeSystem
	{
		private readonly GameContext _gameContext;

		public PlayerSpawnSystem(Contexts contexts) => _gameContext = contexts.game;

		public void Initialize()
		{
			// Create in ECS.
			var playerEntity = _gameContext.CreateEntity();
			playerEntity.AddPosition(Vector3.zero);
			playerEntity.isPlayer = true;

			// Bind View.
			var view = Object.Instantiate(Resources.Load<PositionView>("Player/Player"));
			view.RegisterListener(playerEntity);
			playerEntity.AddGameObject(view.gameObject);
			
			// Add Network Identity to player.
			var identity = playerEntity.gameObject.Value.GetComponent<NetworkIdentity>();
			playerEntity.AddNetworkIdentity(identity);

			// Send to server.
			if (NetworkServer.active)
			{
				NetworkServer.Spawn(playerEntity.gameObject.Value);
			}
		}
	}
}