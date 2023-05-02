using Entitas;
using UnityEngine;

namespace Beta
{
	public sealed class SpawnCursorSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnCursorSystem(Contexts contexts) => _contexts = contexts;

		public void Initialize()
		{
			var e = _contexts.game.CreateEntity();
			e.isCursor = true;
			e.AddPosition(Services.Input.CursorPosition);
			e.AddPositionListener(SpawnPrefab());
		}

		private IPositionListener SpawnPrefab()
		{
			var cursorPrefab = Resources.Load<PositionView>("Player/Cursor");
			return Object.Instantiate(cursorPrefab);
		}
	}
}