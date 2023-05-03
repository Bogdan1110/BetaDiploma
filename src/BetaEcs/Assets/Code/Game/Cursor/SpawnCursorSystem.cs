using Entitas;
using UnityEngine;

namespace Beta
{
	public sealed class SpawnCursorSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnCursorSystem(Contexts contexts) => _contexts = contexts;

		private static PositionView CursorPrefab => Resources.Load<PositionView>(Constants.ResourcePath.Cursor);

		public void Initialize()
		{
			var e = _contexts.game.CreateEntity();
			e.AddDebugName("Cursor");
			e.isCursor = true;
			e.AddPosition(ServicesMediator.Input.CursorPosition);
			e.AddPositionListener(SpawnPrefab());
		}

		private IPositionListener SpawnPrefab() => Object.Instantiate(CursorPrefab);
	}
}