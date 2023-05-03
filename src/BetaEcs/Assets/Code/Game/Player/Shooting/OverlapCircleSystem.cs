using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Beta
{
	public sealed class OverlapCircleSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;
		private readonly Collider2D[] _buffer = new Collider2D[1];
		private readonly Contexts _contexts;

		public OverlapCircleSystem(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.game.GetGroup(AllOf(Id, Position, OverlapCircleRadius));
		}

		private GameEntity CollidedEntity => _contexts.game.GetEntityWithId(CollisionInstanceID);

		private int CollisionInstanceID => _buffer[0].gameObject.GetInstanceID();

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (IsAnyOverlapped(e))
				{
					e.MutualCollideWith(CollidedEntity);
				}
			}
		}

		private bool IsAnyOverlapped(GameEntity entity)
			=> ServicesMediator.Physics.OverlapCircleNonAlloc
			(
				point: entity.position.Value,
				radius: entity.overlapCircleRadius.Value,
				buffer: _buffer
			) > 0;
	}
}