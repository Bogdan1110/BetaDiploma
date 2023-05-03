using Mirror;
using UnityEngine;

namespace Beta
{
	public class BulletSpawner : NetworkBehaviour
	{
		[SerializeField] private Bullet _bulletPrefab;

		public void SpawnBullet(uint owner, Vector2 position, Vector2 target)
		{
			if (isServer)
			{
				SpawnBulletOnServer(owner, target, position);
			}
			else
			{
				CmdSpawnBullet(owner, target, position);
			}
		}

		[Command(requiresAuthority = true)]
		private void CmdSpawnBullet(uint owner, Vector2 target, Vector2 position)
			=> SpawnBulletOnServer(owner, target, position);

		private void SpawnBulletOnServer(uint owner, Vector2 target, Vector2 position)
		{
			var bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
			NetworkServer.Spawn(bullet.gameObject);
			bullet.Initialize(owner, target);
		}
	}
}