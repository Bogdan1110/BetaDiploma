using Entitas;
using UnityEngine;

namespace Beta
{
	public sealed class HelloWorldSystem : IInitializeSystem
	{
		public HelloWorldSystem(Contexts _) { }

		public void Initialize()
		{
			Debug.Log("Hello system!");
		}
	}
}