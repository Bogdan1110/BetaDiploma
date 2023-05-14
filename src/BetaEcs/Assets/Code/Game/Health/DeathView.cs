using Mirror;
using UnityEngine;

namespace Beta
{
	public class DeathView : NetworkBehaviour, IDeadListener
	{
		[SerializeField] private GameObject _gameObject;

		// ReSharper disable once NotAccessedField.Local - mirror moment
		[SyncVar(hook = nameof(OnActiveChanged))] private bool _isGameObjectActive = true;

		private bool SetGameObjectActive
		{
			set
			{
				if (isServer)
				{
					_isGameObjectActive = value;
				}
			}
		}

		public void OnDead(GameEntity entity) => SetGameObjectActive = entity.isDead == false;

		// ReSharper disable once UnusedParameter.Local - mirror moment
		private void OnActiveChanged(bool oldValue, bool newValue) => _gameObject.SetActive(newValue);
	}
}