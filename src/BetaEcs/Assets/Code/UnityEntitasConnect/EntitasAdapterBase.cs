using UnityEngine;

namespace Beta
{
	public abstract class EntitasAdapterBase : MonoBehaviour
	{
		private Feature _fixedUpdateSystems;
		private Feature _systems;

		protected static Contexts Contexts => Contexts.sharedInstance;

		private void Start()
		{
			_systems = GetFeature();
			_fixedUpdateSystems = GetFeatureForFixedUpdate();

			_systems.Initialize();
			_fixedUpdateSystems?.Initialize();
		}

		private void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}

		private void FixedUpdate()
		{
			_fixedUpdateSystems?.Execute();
			_fixedUpdateSystems?.Cleanup();
		}

		private void OnDestroy()
		{
			_systems.TearDown();
			_fixedUpdateSystems?.TearDown();
		}

		protected abstract Feature GetFeature();

		protected virtual Feature GetFeatureForFixedUpdate() => null;
	}
}