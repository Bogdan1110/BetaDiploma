using System.Collections.Generic;
using Entitas;
using Mirror;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Beta
{
	public sealed class SpawnBulletSystem : ReactiveSystem<GameEntity>
	{
		private readonly IGroup<GameEntity> _players;

		public SpawnBulletSystem(Contexts contexts) : base(contexts.game)
		{
			_players = contexts.game.GetGroup(GameMatcher.Player);
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Shoot);

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> shoots)
		{
			foreach (var player in _players)
			{
				if (player.IsOwned() == false)
				{
					continue;
				}

				var networkIdentity = player.networkIdentity.Value;
				var netId = networkIdentity.netId;
				var targetPosition = Services.Camera.ScreenToWorldPoint(Services.Input.CursorPosition);
				var playerPosition = player.position.Value;

				if (networkIdentity.isServer)
				{
					SpawnBullet(netId, targetPosition, playerPosition);
				}
				else
				{
					CmdSpawnBullet(netId, targetPosition, playerPosition);
				}
			}
		}

		[Server]
		private void SpawnBullet(uint owner, Vector2 target, Vector2 position)
		{
			var bullet = Object.Instantiate(BulletPrefab, position, Quaternion.identity);
			NetworkServer.Spawn(bullet.gameObject);
			bullet.GetComponent<Bullet>().Initialize(owner, target);
		}

		[Command(requiresAuthority = false)]
		private void CmdSpawnBullet(uint owner, Vector2 target, Vector2 position)
			=> SpawnBullet(owner, target, position);

		private static Bullet BulletPrefab => Resources.Load<Bullet>("Bullet/Bullet");
	}
}