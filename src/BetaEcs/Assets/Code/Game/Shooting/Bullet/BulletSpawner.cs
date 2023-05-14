using Mirror;
using UnityEngine;

namespace Beta
{
	public class BulletSpawner : NetworkBehaviour
	{
		[SerializeField] private BulletBehaviour _bulletPrefab;

		public void SpawnBullet(uint ownerId, Vector2 from, Vector2 to)
			=> this.Perform
			(
				onServer: SpawnBulletOnServer,
				onClient: CmdSpawnBullet,
				arg1: ownerId,
				arg2: from,
				arg3: to
			);

		[Command]
		private void CmdSpawnBullet(uint owner, Vector2 position, Vector2 target)
			=> SpawnBulletOnServer(owner, position, target);

		private void SpawnBulletOnServer(uint owner, Vector2 position, Vector2 target)
		{
			var bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
			NetworkServer.Spawn(bullet.gameObject);
			bullet.Initialize(owner, target);
		}
	}
}