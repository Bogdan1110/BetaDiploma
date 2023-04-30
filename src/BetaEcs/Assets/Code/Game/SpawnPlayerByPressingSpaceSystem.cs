using Entitas;
using UnityEngine;

namespace Beta
{
	public sealed class SpawnPlayerByPressingSpaceSystem : IExecuteSystem
	{
		private int _counter;
		private readonly Contexts _contexts;

		public SpawnPlayerByPressingSpaceSystem(Contexts contexts) => _contexts = contexts;

		public void Execute()
		{
			if (Input.GetKey(KeyCode.Space)
			    && _counter++ >= 1)
			{
				var e = _contexts.game.CreateEntity();
				e.isPlayer = true;
				e.AddPosition(Vector2.zero);
			}
		}
	}
}