using System.Collections.Generic;
using Entitas;

namespace Beta
{
	public sealed class SpawnBulletsSystem : ReactiveSystem<GameEntity>
	{
		private readonly IGroup<GameEntity> _players;

		private BulletSpawner _bulletSpawner;

		public SpawnBulletsSystem(Contexts contexts)
			: base(contexts.game)
			=> _players = contexts.game.GetGroup(GameMatcher.Player);

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Shoot);

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> shoots)
		{
			foreach (var player in _players)
			{
				if (player.IsOwned())
				{
					player.bulletSpawner.Value.SpawnBullet
					(
						ownerId: player.instanceId.Value,
						from: player.position.Value,
						to: ServicesMediator.CursorWorldPosition
					);
				}
			}
		}
	}
}