using Mirror;
using UnityEngine;

namespace Beta
{
	public class BulletBehaviour : NetworkBehaviour
	{
		[SerializeField] private PositionView _positionView;
		[SerializeField] private NetworkIdentity _networkIdentity;

		private static BulletBalance Balance => ServicesMediator.Balance.Bullet;

		[Server]
		public void Initialize(int ownerInstanceId, Vector2 target)
		{
			var e = Contexts.sharedInstance.game.CreateEntity();
			e.isBullet = true;
			e.AddPosition(transform.position);
			e.AddPositionListener(_positionView);
			e.AddTargetPosition(target);
			e.AddOwnerInstanceId(ownerInstanceId);
			e.AddSpeed(Balance.Speed);
			e.AddNetworkIdentity(_networkIdentity);
			e.AddOverlapCircleRadius(Balance.Radius);
		}
	}
}