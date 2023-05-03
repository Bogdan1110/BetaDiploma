using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class MoveToTargetSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public MoveToTargetSystem(Contexts contexts) 
			=> _entities = contexts.game.GetGroup(AllOf(Position, TargetPosition, Speed));

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var normalizedDelta = (e.targetPosition.Value - e.position.Value).normalized;
				var scaledSpeed = ServicesMediator.Time.DeltaTime * e.speed.Value;
				var delta = normalizedDelta * scaledSpeed;

				e.ReplacePosition(e.position.Value + delta);
			}
		}
	}
}