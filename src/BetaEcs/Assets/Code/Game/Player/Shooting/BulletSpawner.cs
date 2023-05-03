using Mirror;
using UnityEngine;

namespace Beta
{
	public class BulletSpawner : NetworkBehaviour
	{
		[SerializeField] private Bullet _bulletPrefab;

		public void SpawnBullet(int ownerId, Vector2 from, Vector2 to)
		{
			if (isServer)
			{
				SpawnBulletOnServer(ownerId, from, to);
			}
			else
			{
				CmdSpawnBullet(ownerId, from, to);
			}
		}

		[Command]
		private void CmdSpawnBullet(int owner, Vector2 position, Vector2 target)
			=> SpawnBulletOnServer(owner, position, target);

		private void SpawnBulletOnServer(int owner, Vector2 position, Vector2 target)
		{
			var bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
			NetworkServer.Spawn(bullet.gameObject);
			bullet.Initialize(owner, target);
		}
	}
}