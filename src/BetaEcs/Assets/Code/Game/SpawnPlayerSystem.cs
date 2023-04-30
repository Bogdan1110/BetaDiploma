using Entitas;
using Mirror;
using UnityEngine;

namespace Beta
{
	public class SpawnPlayerSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Object _playerPrefab;
		private readonly Contexts _contexts;

		public SpawnPlayerSystem(Contexts contexts, Object playerPrefab)
		{
			_contexts = contexts;
			_playerPrefab = playerPrefab;
		}

		public void Initialize()
		{
			_contexts.game.OnEntityCreated += OnEntityCreated;
		}

		public void Execute()
		{
			if (NetworkServer.active
			    && _playerPrefab != null)
			{
				foreach (var playerEntity in _contexts.game.GetGroup(GameMatcher.Player).GetEntities())
				{
					if (!playerEntity.hasNetworkIdentity)
					{
						var playerObject = AddNetworkIdentity(playerEntity);

						var player = Object.Instantiate(_playerPrefab, playerObject.transform);
						player.name = _playerPrefab.name;

						NetworkServer.Spawn(playerObject);
					}
				}
			}
		}

		private void OnEntityCreated(IContext context, IEntity entity)
		{
			if (entity is GameEntity { isPlayer: true } gameEntity)
			{
				AddNetworkIdentity(gameEntity);
			}
		}

		private static GameObject AddNetworkIdentity(GameEntity gameEntity)
		{
			var player = new GameObject();
			var networkIdentity = player.AddComponent<NetworkIdentity>();

			gameEntity.AddNetworkIdentity(networkIdentity);
			return player;
		}
	}
}