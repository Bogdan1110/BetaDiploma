using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Beta
{
	public sealed class ClampPlayerPositionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		private const float Border = 8;

		public ClampPlayerPositionSystem(Contexts contexts)
		{
			_entities = contexts.game.GetGroup(AllOf(Player, Position));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var x = Mathf.Clamp(e.position.Value.x, -Border, Border);
				var y = Mathf.Clamp(e.position.Value.y, -Border, Border);

				e.ReplacePosition(new Vector2(x, y));
			}
		}
	}
}