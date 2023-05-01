using Entitas;

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
		}
	}
}