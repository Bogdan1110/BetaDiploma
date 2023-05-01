namespace Beta
{
	public static class Services
	{
		public static IInputService Input => Context.inputService.Value;

		public static IBalanceService Balance => Context.balanceService.Value;

		public static ITimeService Time => Context.timeService.Value;

		private static ServicesContext Context => Contexts.sharedInstance.services;
	}
}