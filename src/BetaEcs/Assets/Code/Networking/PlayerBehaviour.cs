using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Beta
{
	public class PlayerBehaviour : NetworkBehaviour
	{
		[SerializeField] private NetworkIdentity _networkIdentity;
		[SerializeField] private PositionView _positionView;
		[SerializeField] private RotationView _rotationView;
		[SerializeField] private BulletSpawner _bulletSpawner;
		[SerializeField] private int _health;
		[SerializeField] private int _maxHealth;
		[SerializeField] private Slider _healthBar;

		[SyncVar(hook = nameof(SyncHealth))] private int _syncHealth;

		private void Start()
		{
			_healthBar.maxValue = _maxHealth;

			var e = Contexts.sharedInstance.game.CreateEntity();
			e.isPlayer = true;
			e.isHittable = true;
			e.AddId(netId);
			e.AddNetworkIdentity(_networkIdentity);
			e.AddPosition(transform.position);
			e.AddPositionListener(_positionView);
			e.AddRotation(0f);
			e.AddRotationListener(_rotationView);
			e.AddBulletSpawner(_bulletSpawner);
		}

		private void Update()
		{
			_healthBar.value = _health;

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
		}

		private void SyncHealth(int oldValue, int newValue) => _health = newValue;

		[Command]
		public void CmdChangeHealth(int newValue) => ChangeHealthValue(newValue);

		[Server]
		public void ChangeHealthValue(int newValue) => _syncHealth = newValue;
	}
}