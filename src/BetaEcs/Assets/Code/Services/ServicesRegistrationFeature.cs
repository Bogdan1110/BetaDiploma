using System;
using UnityEngine;

namespace Beta
{
	public sealed class ServicesRegistrationFeature : Feature
	{
		public ServicesRegistrationFeature(Contexts contexts)
			: base(nameof(ServicesRegistrationFeature))
		{
			Register<IInputService>(new OldInputService(), contexts.services.ReplaceInputService);
			Register<IBalanceService>(LoadBalance(), contexts.services.ReplaceBalanceService);
			Register<ITimeService>(new TimeService(), contexts.services.ReplaceTimeService);
		}

		private static Balance LoadBalance() => Resources.Load<Balance>(Constants.ResourcePath.Balance);

		private void Register<TService>(TService service, Action<TService> replace)
			=> Add(new RegisterServiceSystem<TService>(service, replace));
	}
}