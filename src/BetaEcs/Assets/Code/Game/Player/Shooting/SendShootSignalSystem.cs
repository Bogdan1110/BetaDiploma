using Entitas;

namespace Beta
{
	public sealed class SendShootSignalSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		public SendShootSignalSystem(Contexts contexts) => _contexts = contexts;

		public void Execute()
		{
			if (ServicesMediator.Input.IsLeftMouseButtonClicked)
			{
				var shootSignal = _contexts.game.CreateEntity();
				shootSignal.isShoot = true;
				shootSignal.markToDestroy = true;
			}
		}
	}
}