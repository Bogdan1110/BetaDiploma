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
			Register<IBalanceService>(BalanceFile, contexts.services.ReplaceBalanceService);
		}

		private static Balance BalanceFile => Resources.Load<Balance>(Constants.ResourcePath.Balance);

		private void Register<TService>(TService service, Action<TService> replace)
			=> Add(new RegisterServiceSystem<TService>(service, replace));
	}
}