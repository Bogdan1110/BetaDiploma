using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Beta
{
	public class HealthBar : NetworkBehaviour, ICurrentHealthListener, IMaxHealthListener
	{
		[SerializeField] private int _health;
		[SerializeField] private int _maxHealth;
		[SerializeField] private Slider _healthBar;

		// ReSharper disable once NotAccessedField.Local - mirror
		[SyncVar(hook = nameof(SyncHealth))] private int _syncCurrentHealth;
		// ReSharper disable once NotAccessedField.Local - mirror
		[SyncVar(hook = nameof(SyncMaxHealth))] private int _syncMaxHealth;

		public void RegisterListener(GameEntity e)
		{
			e.AddCurrentHealthListener(this);
			e.AddMaxHealthListener(this);

			if (e.hasCurrentHealth)
			{
				OnCurrentHealth(e, e.currentHealth.Value);
			}

			if (e.hasMaxHealth)
			{
				OnMaxHealth(e, e.currentHealth.Value);
			}
		}

		public void OnCurrentHealth(GameEntity entity, int value)
		{
			if (isOwned == false)
			{
				return;
			}

			if (isServer)
			{
				ChangeHealthValue(value);
			}
			else
			{
				CmdChangeHealth(value);
			}

			UpdateHealthBar();
		}

		public void OnMaxHealth(GameEntity entity, int value)
		{
			if (isOwned == false)
			{
				return;
			}

			if (isServer)
			{
				CmdChangeMaxHealth(value);
			}
			else
			{
				CmdChangeMaxHealth(value);
			}

			UpdateHealthBar();
		}

		private void UpdateHealthBar()
		{
			_healthBar.value = _health;
			_healthBar.maxValue = _maxHealth;
		}

		// ReSharper disable once UnusedParameter.Local - mirror
		private void SyncHealth(int oldValue, int newValue) => _health = newValue;

		// ReSharper disable once UnusedParameter.Local - mirror
		private void SyncMaxHealth(int oldValue, int newValue) => _maxHealth = newValue;

		[Command] private void CmdChangeHealth(int newValue) => ChangeHealthValue(newValue);

		[Server] private void ChangeHealthValue(int newValue) => _syncCurrentHealth = newValue;

		[Command] private void CmdChangeMaxHealth(int newValue) => ChangeMaxHealth(newValue);

		[Server] private void ChangeMaxHealth(int newValue) => _syncMaxHealth = newValue;
	}
}