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

		private static PlayerBalance Balance => ServicesMediator.Balance.Player;

		private void Start()
		{
			var e = Contexts.sharedInstance.game.CreateEntity();
			e.isPlayer = true;
			e.isHittable = true;
			e.AddId(netId);
			e.AddNetworkIdentity(_networkIdentity);
			e.AddBulletSpawner(_bulletSpawner);
			e.AddSpeed(Balance.Speed);

			TransformSetup(e);
			HealthSetup(e);
		}

		private void HealthSetup(GameEntity e)
		{
			e.AddCurrentHealth(Balance.MaxHealth);
			e.AddCurrentHealthListener(_healthBar);

			e.AddMaxHealth(Balance.MaxHealth);
			e.AddMaxHealthListener(_healthBar);
		}

		private void TransformSetup(GameEntity e)
		{
			e.AddPosition(transform.position);
			e.AddPositionListener(_positionView);

			e.AddRotation(transform.rotation.z);
			e.AddRotationListener(_rotationView);
		}
	}
}