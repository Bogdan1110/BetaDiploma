using System.Linq;
using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Beta
{
	public class PlayerMovementSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _players;

		public PlayerMovementSystem(Contexts contexts)
			=> _players = contexts.game.GetGroup(AllOf(Player, NetworkIdentity));

		public void Execute()
		{
			foreach (var playerEntity in _players.GetEntities().Where((e) => e.networkIdentity.Value.isOwned))
			{
				var moveHorizontal = Input.GetAxis("Horizontal");
				var moveVertical = Input.GetAxis("Vertical");
				var movement = new Vector2(moveHorizontal, moveVertical) * Time.deltaTime * 5f;

				playerEntity.ReplacePosition(playerEntity.position.Value + movement);
			}
		}
	}
}