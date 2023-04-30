using Entitas;
using UnityEngine;

namespace Beta
{
	public sealed class MovePlayer : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;
		private float _speed = 5f;

		public MovePlayer(Contexts contexts) => _entities = contexts.game.GetGroup(GameMatcher.Player);

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				var scaledSpeed = _speed * Time.deltaTime;

				e.ReplacePosition(e.position.Value + direction * scaledSpeed);
			}
		}
	}
}