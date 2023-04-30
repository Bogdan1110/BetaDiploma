using Entitas;
using static GameMatcher;

namespace Beta
{
	public class SyncPlayerSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _players;

		public SyncPlayerSystem(Contexts contexts)
			=> _players = contexts.game.GetGroup(AllOf(Player, NetworkIdentity));

		public void Execute()
		{
			foreach (var playerEntity in _players.GetEntities())
			{
				var transform = playerEntity.networkIdentity.Value.transform;
				playerEntity.ReplacePosition(transform.position);
			}
		}
	}
}