using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class ResetBalanceValuesSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public ResetBalanceValuesSystem(Contexts contexts) => _entities = contexts.game.GetGroup(Speed);

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (e.isPlayer)
				{
					e.speed.Value = ServicesMediator.Balance.Player.Speed;
				}

				if (e.isBullet)
				{
					e.speed.Value = ServicesMediator.Balance.Bullet.Speed;
				}
			}
		}
	}
}