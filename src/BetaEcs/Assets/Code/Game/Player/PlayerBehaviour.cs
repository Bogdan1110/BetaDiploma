using Mirror;
using UnityEngine;

namespace Beta
{
	public class PlayerBehaviour : NetworkBehaviour
	{
		[SerializeField] private NetworkIdentity _networkIdentity;
		[SerializeField] private PositionView _positionView;
		[SerializeField] private RotationView _rotationView;
		[SerializeField] private BulletSpawner _bulletSpawner;
		[SerializeField] private HealthBar _healthBar;
		[SerializeField] private DeathView _deathView;

		private GameEntity _entity;

		private static PlayerBalance Balance => ServicesMediator.Balance.Player;

		private void Start() => CreateEntity();

		private void CreateEntity()
		{
			_entity = Contexts.sharedInstance.game.CreateEntity();
			_entity.AddDebugName($"Player (netId: {netId})");
			_entity.isPlayer = true;
			_entity.isHittable = true;
			_entity.AddId(netId);
			_entity.AddNetworkIdentity(_networkIdentity);
			_entity.AddBulletSpawner(_bulletSpawner);
			_entity.AddSpeed(Balance.Speed);
			_entity.AddDeadListener(_deathView);
			TransformSetup();
			HealthSetup();
		}

		private void TransformSetup()
		{
			_entity.AddPosition(transform.position);
			_entity.AddPositionListener(_positionView);

			_entity.AddRotation(transform.rotation.z);
			_entity.AddRotationListener(_rotationView);
		}

		private void HealthSetup()
		{
			_entity.AddCurrentHealth(Balance.MaxHealth);
			_entity.AddMaxHealth(Balance.MaxHealth);

			_healthBar.RegisterListener(_entity);
		}

		private void OnDestroy()
		{
			_entity.InternalDestroy();

			if (isLocalPlayer)
			{
				ReviveScreen.Instance.Show();
			}
		}
	}
}