using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Beta.Health
{
	public class HealthBar : NetworkBehaviour
	{
		[SerializeField] private int _health;
		[SerializeField] private int _maxHealth;
		[SerializeField] private Slider _healthBar;

		// ReSharper disable once NotAccessedField.Local - mirror
		[SyncVar(hook = nameof(SyncHealth))] private int _syncHealth;

		private void Start()
		{
			_healthBar.maxValue = _maxHealth;
		}

		private void Update()
		{
			if (isOwned)
			{
				if (Input.GetKeyDown(KeyCode.H))
				{
					if (isServer)
					{
						ChangeHealthValue(_health - 5);
					}
					else
					{
						CmdChangeHealth(_health - 5);
					}
				}
			}

			_healthBar.value = _health;
		}

		// ReSharper disable once UnusedParameter.Local - mirror
		private void SyncHealth(int oldValue, int newValue) => _health = newValue;

		[Command] private void CmdChangeHealth(int newValue) => ChangeHealthValue(newValue);

		[Server] private void ChangeHealthValue(int newValue) => _syncHealth = newValue;
	}
}