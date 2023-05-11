using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Beta
{
	public sealed class ClampPlayerPositionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public ClampPlayerPositionSystem(Contexts contexts)
			=> _entities = contexts.game.GetGroup(AllOf(Player, Position));

		private static FieldBalance Field => ServicesMediator.Balance.Field;

		public void Execute()
		{
			foreach (var e in _entities)
			{
				e.ReplacePosition(ClampPosition(e));
			}
		}

		private static Vector2 ClampPosition(GameEntity e)
			=> e.position.Value.Clamp(Field.MinPositions, Field.MaxPositions);
	}
}