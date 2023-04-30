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
			foreach (var playerEntity in _players.GetEntities())
			{
				// Get input and calculate movement
				var moveHorizontal = Input.GetAxis("Horizontal");
				var moveVertical = Input.GetAxis("Vertical");
				var movement = new Vector3(moveHorizontal, moveVertical);

				// Update the Mirror player object's position and rotation
				var transform = playerEntity.networkIdentity.Value.transform;
				transform.position += movement * 5f * Time.deltaTime;
			}
		}
	}
}