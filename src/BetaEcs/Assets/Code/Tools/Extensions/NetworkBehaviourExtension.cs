using System;
using Mirror;

namespace Beta
{
	public static class NetworkBehaviourExtension
	{
		public static void Perform(this NetworkBehaviour @this, Action onServer, Action onClient)
		{
			if (@this.isServer)
			{
				onServer.Invoke();
			}
			else
			{
				onClient.Invoke();
			}
		}

		public static void Perform<T>(this NetworkBehaviour @this, Action<T> onServer, Action<T> onClient, T arg)
		{
			if (@this.isServer)
			{
				onServer.Invoke(arg);
			}
			else
			{
				onClient.Invoke(arg);
			}
		}

		public static void Perform<T1, T2>
		(
			this NetworkBehaviour @this,
			Action<T1, T2> onServer,
			Action<T1, T2> onClient,
			T1 arg1,
			T2 arg2
		)
		{
			if (@this.isServer)
			{
				onServer.Invoke(arg1, arg2);
			}
			else
			{
				onClient.Invoke(arg1, arg2);
			}
		}

		public static void Perform<T1, T2, T3>
		(
			this NetworkBehaviour @this,
			Action<T1, T2, T3> onServer,
			Action<T1, T2, T3> onClient,
			T1 arg1,
			T2 arg2,
			T3 arg3
		)
		{
			if (@this.isServer)
			{
				onServer.Invoke(arg1, arg2, arg3);
			}
			else
			{
				onClient.Invoke(arg1, arg2, arg3);
			}
		}
	}
}