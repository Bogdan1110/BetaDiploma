namespace Beta
{
	public static class Services
	{
		public static IInputService Input => Context.inputService.Value;

		private static ServicesContext Context => Contexts.sharedInstance.services;
	}
}