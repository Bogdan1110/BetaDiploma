using Mirror;
using UnityEngine;

namespace Beta
{
	public class BulletBehaviour : NetworkBehaviour
	{
		[SerializeField] private PositionView _positionView;
		[SerializeField] private NetworkIdentity _networkIdentity;

		[Server]
		public void Initialize(int ownerInstanceId, Vector2 target)
		{
			var e = Contexts.sharedInstance.game.CreateEntity();
			e.isBullet = true;
			e.AddPosition(transform.position);
			e.AddPositionListener(_positionView);
			e.AddTargetPosition(target);
			e.AddOwnerInstanceId(ownerInstanceId);
			e.AddSpeed(ServicesMediator.Balance.Bullet.Speed);
			e.AddNetworkIdentity(_networkIdentity);
		}
	}
}