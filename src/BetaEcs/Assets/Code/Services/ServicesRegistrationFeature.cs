using System;

namespace Beta
{
	public sealed class ServicesRegistrationFeature : Feature
	{
		public ServicesRegistrationFeature(Contexts contexts)
			: base(nameof(ServicesRegistrationFeature))
		{
			Register<IInputService>(new OldInputService(), contexts.services.ReplaceInputService);
		}
		
		private void Register<TService>(TService service, Action<TService> replace)
			=> Add(new RegisterServiceSystem<TService>(service, replace));
	}
}