using System.Linq;
using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Beta
{
	public class PlayerMovementSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _entities;

		public PlayerMovementSystem(Contexts contexts)
		{
			_contexts = contexts;
			_entities = _contexts.game.GetGroup(AllOf(Player, Position, NetworkIdentity));
		}

		private Vector2 Movement => Input.MovementDirection * Time.deltaTime * BalancePlayerSpeed;

		private static float BalancePlayerSpeed => 5f;

		private IInputService Input => _contexts.services.inputService.Value;

		public void Execute()
		{
			foreach (var e in _entities.GetEntities().Where(IsOwned))
			{
				e.ReplacePosition(e.position.Value + Movement);
			}
		}

		private static bool IsOwned(GameEntity entity) => entity.networkIdentity.Value.isOwned;
	}
}