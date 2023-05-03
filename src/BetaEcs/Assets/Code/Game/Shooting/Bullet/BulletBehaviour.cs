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
		public void Initialize(uint ownerId, Vector2 target)
		{
			var e = Contexts.sharedInstance.game.CreateEntity();
			e.AddDebugName("Bullet");
			e.isBullet = true;
			e.isDestroyUponReachingTarget = true;
			e.AddId(netId);
			e.AddPosition(transform.position);
			e.AddPositionListener(_positionView);
			e.AddTargetPosition(target);
			e.AddOwnerId(ownerId);
			e.AddSpeed(Balance.Speed);
			e.AddNetworkIdentity(_networkIdentity);
			e.AddOverlapCircleRadius(Balance.Radius);
			e.AddDamage(Balance.Damage);
		}
	}
}