using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Beta
{
	public sealed class OverlapCircleSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;
		private readonly Collider2D[] _buffer = new Collider2D[1];

		public OverlapCircleSystem(Contexts contexts)
			=> _entities = contexts.game.GetGroup(AllOf(Position, OverlapCircleRadius));

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (Overlap(e) > 0)
				{
					var collision = Collision;
					var instanceID = collision.GetInstanceID();
					Debug.Log($"Collided with instanceID = {instanceID}");
				}
			}
		}

		private Collider2D Collision => _buffer[0];

		private int Overlap(GameEntity entity)
			=> ServicesMediator.Physics.OverlapCircleNonAlloc
			(
				point: entity.position.Value,
				radius: entity.overlapCircleRadius.Value,
				buffer: _buffer
			);
	}
}