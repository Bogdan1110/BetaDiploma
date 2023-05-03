using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class ResetBalanceValuesSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public ResetBalanceValuesSystem(Contexts contexts) => _entities = contexts.game.GetGroup(AnyOf(Player, Bullet));

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (e.isPlayer)
				{
					e.ReplaceSpeed(ServicesMediator.Balance.Player.Speed);
				}

				if (e.isBullet)
				{
					e.ReplaceSpeed(ServicesMediator.Balance.Bullet.Speed);
				}
			}
		}
	}
}