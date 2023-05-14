using Mirror;
using UnityEngine;

namespace Beta
{
	public class DeathView : NetworkBehaviour, IDeadListener
	{
		[SerializeField] private GameObject _gameObject;

		// ReSharper disable once NotAccessedField.Local - mirror moment
		[SyncVar(hook = nameof(OnActiveChanged))] private bool _isActive = true;

		private bool Active
		{
			set
			{
				if (isServer)
				{
					_isActive = value;
				}
			}
		}

		public void OnDead(GameEntity entity) => Active = !entity.isDead;

		// ReSharper disable once UnusedParameter.Local - mirror moment
		private void OnActiveChanged(bool oldValue, bool newValue) => _gameObject.SetActive(newValue);
	}
}