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

		private void Start()
		{
			var e = Contexts.sharedInstance.game.CreateEntity();
			e.isPlayer = true;
			e.AddNetworkIdentity(_networkIdentity);
			e.AddPosition(transform.position);
			e.AddPositionListener(_positionView);
			e.AddRotation(0f);
			e.AddRotationListener(_rotationView);
			e.AddBulletSpawner(_bulletSpawner);
		}
	}
}