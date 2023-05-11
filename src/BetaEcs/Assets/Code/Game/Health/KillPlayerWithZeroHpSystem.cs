using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class KillPlayerWithZeroHpSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public KillPlayerWithZeroHpSystem(Contexts contexts)
			=> _entities = contexts.game.GetGroup(AllOf(Player, CurrentHealth));

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (e.currentHealth.Value <= 0)
				{
					e.isDead = true;
				}
			}
		}
	}
}