using System.Linq;
using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Beta
{
	public class PlayerMovementSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public PlayerMovementSystem(Contexts contexts)
			=> _entities = contexts.game.GetGroup(AllOf(Player, Position, NetworkIdentity));

		private static Vector2 Movement => ServicesMediator.Input.MovementDirection
		                                   * ServicesMediator.Time.DeltaTime
		                                   * ServicesMediator.Balance.Player.Speed;

		public void Execute()
		{
			foreach (var e in _entities.GetEntities().Where(IsOwned))
			{
				e.ReplacePosition(e.position.Value + Movement);
			}
		}

		private static bool IsOwned(GameEntity entity) => entity.IsOwned();
	}
}