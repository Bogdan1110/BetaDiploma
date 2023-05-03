using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Beta
{
	public sealed class LookAtTargetSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public LookAtTargetSystem(Contexts contexts) => _entities = contexts.game.GetGroup(AllOf(LookAt, Rotation));

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var lookObject = e.lookAt.Value;
				var angle = CalculateDelta(lookObject.position.Value, e.position.Value) * Mathf.Rad2Deg;

				e.ReplaceRotation(angle);
			}
		}

		private static float CalculateDelta(Vector2 @object, Vector2 subject)
			=> Mathf.Atan2(@object.y - subject.y, @object.x - subject.x);
	}
}