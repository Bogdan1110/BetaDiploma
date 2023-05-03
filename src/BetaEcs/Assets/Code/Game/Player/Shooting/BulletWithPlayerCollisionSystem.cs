using Entitas;
using UnityEngine;
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
			_hittables = contexts.game.GetGroup(AllOf(Hittable, Collided, Id).NoneOf(Hit));
		}

		public void Execute()
		{
			foreach (var hittable in _hittables)
			foreach (var bullet in _bullets)
			{
				if (hittable.id.Value == bullet.collisionId.Value)
				{
					hittable.isHit = true;
					Debug.Log($"target id {hittable.id.Value}\n bullet.id {bullet.id.Value}\n bullet owner {bullet.ownerId.Value}");
				}
			}
		}
	}
}