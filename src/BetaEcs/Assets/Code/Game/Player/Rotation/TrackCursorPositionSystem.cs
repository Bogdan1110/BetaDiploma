using Entitas;
using static GameMatcher;

namespace Beta
{
	public sealed class TrackCursorPositionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public TrackCursorPositionSystem(Contexts contexts)
			=> _entities = contexts.game.GetGroup(AllOf(GameMatcher.Cursor, Position));

		public void Execute()
		{
			foreach (var e in _entities)
			{
				e.ReplacePosition(Services.Camera.ScreenToWorldPoint(Services.Input.CursorPosition));
			}
		}
	}
}