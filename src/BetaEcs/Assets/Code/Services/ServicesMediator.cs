using UnityEngine;

namespace Beta
{
	public static class ServicesMediator
	{
		public static IInputService Input => Context.inputService.Value;

		public static IBalanceService Balance => Context.balanceService.Value;

		public static ITimeService Time => Context.timeService.Value;

		public static ICameraService Camera => Context.cameraService.Value;

		public static IPhysicsService Physics => Context.physicsService.Value;

		public static Vector2 CursorWorldPosition => Camera.ScreenToWorldPoint(Input.CursorPosition);

		private static ServicesContext Context => Contexts.sharedInstance.services;
	}
}