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

		private static PlayerBalance Balance => ServicesMediator.Balance.Player;

		private void Start()
		{
			var e = Contexts.sharedInstance.game.CreateEntity();
			e.AddDebugName($"Player (netId: {netId})");
			e.isPlayer = true;
			e.isHittable = true;
			e.AddId(netId);
			e.AddNetworkIdentity(_networkIdentity);
			e.AddBulletSpawner(_bulletSpawner);
			e.AddSpeed(Balance.Speed);
			e.AddDeadListener(_deathView);
			TransformSetup(e);
			HealthSetup(e);
		}

		private void TransformSetup(GameEntity e)
		{
			e.AddPosition(transform.position);
			e.AddPositionListener(_positionView);

			e.AddRotation(transform.rotation.z);
			e.AddRotationListener(_rotationView);
		}

		private void HealthSetup(GameEntity e)
		{
			e.AddCurrentHealth(Balance.MaxHealth);
			e.AddMaxHealth(Balance.MaxHealth);
			
			_healthBar.RegisterListener(e);
		}
        private void OnDestroy()
        {
            Contexts.sharedInstance.game.DestroyAllEntities();
        }
    }
}