using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class DestroyReachedTargetEntitesSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public DestroyReachedTargetEntitesSystem(Contexts contexts) 
			=> _entities = contexts.game.GetGroup(AllOf(Position, TargetPosition, DestroyUponReachingTarget));

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (e.position.Value.DistanceTo(e.targetPosition.Value) < Constants.Deviation)
				{
					e.markToDestroy = true;
				}
			}
		}
	}
}