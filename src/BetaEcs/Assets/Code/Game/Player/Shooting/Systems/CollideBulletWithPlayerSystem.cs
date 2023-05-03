using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class CollideBulletWithPlayerSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _bullets;
		private readonly IGroup<GameEntity> _hittables;

		public CollideBulletWithPlayerSystem(Contexts contexts)
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
				    && hittable.hasDamageDealt == false)
				{
					hittable.AddDamageDealt(bullet.damage.Value);
				}
			}
		}
	}
}