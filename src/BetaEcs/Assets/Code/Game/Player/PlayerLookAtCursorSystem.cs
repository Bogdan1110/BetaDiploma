using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class PlayerLookAtCursorSystem : ReactiveSystem<GameEntity>
	{
		private readonly IGroup<GameEntity> _cursors;

		public PlayerLookAtCursorSystem(Contexts contexts) : base(contexts.game)
			=> _cursors = contexts.game.GetGroup(AllOf(Cursor));

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(Player);

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var player in entities)
			foreach (var cursor in _cursors)
			{
				if (player.IsOwned())
				{
					player.AddLookAt(cursor);
				}
			}
		}
	}
}