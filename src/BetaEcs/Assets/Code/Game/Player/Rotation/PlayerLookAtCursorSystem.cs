using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class PlayerLookAtCursorSystem : ReactiveSystem<GameEntity>
	{
		private readonly IGroup<GameEntity> _players;

		public PlayerLookAtCursorSystem(Contexts contexts) : base(contexts.game)
			=> _players = contexts.game.GetGroup(AllOf(Player));

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(Cursor);

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var cursor in entities)
			foreach (var player in _players)
			{
				if (player.IsOwned())
				{
					player.AddLookAt(cursor);
				}
			}
		}
	}
}