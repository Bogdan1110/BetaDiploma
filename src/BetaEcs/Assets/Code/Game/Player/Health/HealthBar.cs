using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Beta
{
	public class HealthBar : NetworkBehaviour, ICurrentHealthListener, IMaxHealthListener
	{
		[SerializeField] private Slider _healthBar;

		private float CurrentHealth { set => _healthBar.value = value; }
		private float MaxHealth     { set => _healthBar.maxValue = value; }

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
			CurrentHealth = _syncCurrentHealth;
			MaxHealth = _syncMaxHealth;
		}

		// ReSharper disable once UnusedParameter.Local - mirror
		private void SyncHealth(int oldValue, int newValue) => CurrentHealth = newValue;

		// ReSharper disable once UnusedParameter.Local - mirror
		private void SyncMaxHealth(int oldValue, int newValue) => MaxHealth = newValue;

		[Command(requiresAuthority = false)] private void CmdChangeHealth(int newValue) => ChangeHealthValue(newValue);

		[Server]
		private void ChangeHealthValue(int newValue)
		{
			_syncCurrentHealth = newValue;
			RpcChangeHealth(newValue);
		}

		[ClientRpc] private void RpcChangeHealth(int newValue) => CurrentHealth = newValue;

		[Command(requiresAuthority = false)] private void CmdChangeMaxHealth(int newValue) => ChangeMaxHealth(newValue);

		[Server]
		private void ChangeMaxHealth(int newValue)
		{
			_syncMaxHealth = newValue;
			RpcChangeMaxHealth(newValue);
		}

		[ClientRpc] private void RpcChangeMaxHealth(int newValue) => MaxHealth = newValue;
	}
}