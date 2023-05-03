using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Beta
{
	public sealed class BulletWithPlayerCollisionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _bullets;
		private readonly IGroup<GameEntity> _targets;

		public BulletWithPlayerCollisionSystem(Contexts contexts)
		{
			_bullets = contexts.game.GetGroup(AllOf(Collided, CollisionId));
			_targets = contexts.game.GetGroup(AllOf(Collided, Id));
		}

		public void Execute()
		{
			foreach (var target in _targets)
			foreach (var bullet in _bullets)
			{
				if (target.id.Value == bullet.collisionId.Value
				    || bullet.id.Value == target.collisionId.Value)
				{
					target.isHit = true;
					Debug.Log($"target {target.id} is hit");
				}
			}
		}
	}
}