using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class BulletWithPlayerCollisionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _bullets;
		private readonly IGroup<GameEntity> _hittables;

		public BulletWithPlayerCollisionSystem(Contexts contexts)
		{
			_bullets = contexts.game.GetGroup(AllOf(Bullet, Collided, CollisionId));
			_hittables = contexts.game.GetGroup(AllOf(Hittable, Collided, Id));
		}

		public void Execute()
		{
			foreach (var hittable in _hittables)
			foreach (var bullet in _bullets)
			{
				if (hittable.id.Value == bullet.collisionId.Value
				    && hittable.isHit == false)
				{
					hittable.isHit = true;
				}
			}
		}
	}
}