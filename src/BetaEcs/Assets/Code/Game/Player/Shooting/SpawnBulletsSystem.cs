using System.Collections.Generic;
using Entitas;
using Object = UnityEngine.Object;

namespace Beta
{
	public sealed class SpawnBulletsSystem : ReactiveSystem<GameEntity>
	{
		private readonly IGroup<GameEntity> _players;

		private BulletSpawner _bulletSpawner;

		public SpawnBulletsSystem(Contexts contexts)
			: base(contexts.game)
			=> _players = contexts.game.GetGroup(GameMatcher.Player);

		private BulletSpawner BulletSpawner => _bulletSpawner ??= Object.FindObjectOfType<BulletSpawner>();

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
				var targetPosition = ServicesMediator.CursorWorldPosition;
				var playerPosition = player.position.Value;

				BulletSpawner.SpawnBullet(netId, playerPosition, targetPosition);
			}
		}
	}
}